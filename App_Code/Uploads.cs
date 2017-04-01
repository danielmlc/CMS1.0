using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
///Uploads 的摘要说明
/// </summary>
public class Uploads
{
	public Uploads()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    static public string Init(string path)
    {
        if (Core.isPost())
        {
            path = HttpContext.Current.Server.MapPath(path);

            int maxattachsize = 10485760;     // 最大上传大小
            byte[] file;                      // 统一转换为byte数组处理
            string localname = "";
            string disposition = HttpContext.Current.Request.ServerVariables["HTTP_CONTENT_DISPOSITION"];

            if (disposition != null)
            {
                // HTML5上传
                file = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);

                // 读取原始文件名
                localname = Regex.Match(disposition, "filename=\"(.+?)\"").Groups[1].Value;
            }
            else
            {
                HttpFileCollection filecollection = HttpContext.Current.Request.Files;
                HttpPostedFile postedfile = filecollection.Get(0);

                // 读取原始文件名
                localname = postedfile.FileName;

                // 初始化byte长度.
                file = new Byte[postedfile.ContentLength];

                // 转换为byte类型
                System.IO.Stream stream = postedfile.InputStream;
                stream.Read(file, 0, postedfile.ContentLength);
                stream.Close();

                filecollection = null;
            }

            if (file.Length <= maxattachsize)
            {
                string ext = GetFileExt(localname);

                if ("|zip|rar|7z|doc|docx|".IndexOf("|" + ext + "|") == -1)
                {
                    return "-1";
                }
                else
                {
                    localname = DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ext;

                    File.WriteAllBytes(path + localname, file);

                    return localname;
                }
            }
        }
        return "";
    }

    static string GetFileExt(string FullPath)
    {
        if (FullPath != "") return FullPath.Substring(FullPath.LastIndexOf('.') + 1).ToLower();
        else return "";
    }
}