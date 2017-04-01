using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///html 的摘要说明
/// </summary>
public class html
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public int USER_ID
    {
        get { return Core.Cookies("USER_ID") == "" ? 0 : int.Parse(Core.Cookies("USER_ID")); }
        set { Core.Cookies("USER_ID", value.ToString()); }
    }

    /// <summary>
    /// 用户昵称
    /// </summary>
    public string USER_NiName
    {
        get { return Core.Cookies("USER_NiName"); }
        set { Core.Cookies("USER_NiName", value); }
    }
    /// <summary>
    /// 用户登陆账号
    /// </summary>
    public string  USER_USERNAME
    {
        get { return Core.Cookies("USER_USERNAME"); }
        set { Core.Cookies("USER_USERNAME", value); }
    }
    /// <summary>
    /// 用户登陆账号
    /// </summary>
    public string USER_REAlNAME
    {
        get { return Core.Cookies("USER_REAlNAME"); }
        set { Core.Cookies("USER_REAlNAME", value); }
    }
 

}