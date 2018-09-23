using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for FormHandler
/// </summary>
public class FormHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        HttpResponse resp = context.Response;
        HttpRequest req = context.Request;

        string basePath = HttpRuntime.AppDomainAppPath;

        string body = File.ReadAllText(basePath + "bodyForm.html");
        string result = "";

        if (req.Params.Count > 0 && req.Params["aValue"] != null && req.Params["bValue"] != null && req.Params["cValue"] != null)
        {

            result = Calculator.Calculate(req.Params["aValue"], req.Params["bValue"], req.Params["cValue"]);
        }


        string output = String.Format(body, result);

        resp.Write(output);

    }

    public bool IsReusable
    {
        get { return false; }
    }
}