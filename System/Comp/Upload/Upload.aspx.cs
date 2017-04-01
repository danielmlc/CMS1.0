using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

public partial class Programs_Upload : systempage
{
    string root = "/UpFiles/";
    string path = DateTime.Now.ToString("yyyyMM");

    private void chkPath(string _path)
    {
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Core.isPost())
        {
            string rootpath = Server.MapPath(root + path);

            chkPath(rootpath);

            int maxattachsize = 10485760;     // 最大上传大小
            byte[] file;                      // 统一转换为byte数组处理
            string localname = "";
            string disposition = Request.ServerVariables["HTTP_CONTENT_DISPOSITION"];

            if (disposition != null)
            {
                // HTML5上传
                file = Request.BinaryRead(Request.TotalBytes);

                // 读取原始文件名
                localname = Regex.Match(disposition, "filename=\"(.+?)\"").Groups[1].Value;
            }
            else
            {
                HttpFileCollection filecollection = Request.Files;
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
                localname = DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ext;

                File.WriteAllBytes(rootpath + "\\" + localname, file);
            }

            Response.Clear();
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write("{'err':'','msg':'" + root + path + "/" + localname + "'}");
            Response.End();
        }
    }

    string GetFileExt(string FullPath)
    {
        if (FullPath != "") return FullPath.Substring(FullPath.LastIndexOf('.') + 1).ToLower();
        else return "";
    }
}