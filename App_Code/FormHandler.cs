using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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

        if (req.Params["aValue"] != null && req.Params["bValue"] != null && req.Params["cValue"] != null)
        {
            string aVal = req.Params["aValue"];
            string bVal = req.Params["bValue"];
            string cVal = req.Params["cValue"];

            if (aVal.Length > 0 && bVal.Length > 0 && cVal.Length > 0)
            {
                result = Calculator.Calculate(aVal, bVal, cVal);
            }
            else
            {
                result = "Please fill in all fiedls";
            }
           
        }

        string output = String.Format(body, result);

        resp.Write(output);

    }

    public bool IsReusable
    {
        get { return false; }
    }
}