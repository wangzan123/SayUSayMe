<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;

/// <summary>
/// ImageHandler 的摘要说明
/// </summary>
public class ImageHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        if ((context.Session["imge"]) != null)
        {
            context.Response.ContentType = "image/jpeg";
            byte[] byts = (byte[])context.Session["imge"];
            context.Response.BinaryWrite(byts);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}