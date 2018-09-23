using System;
using System.IO;
using System.ServiceModel.Channels;
using System.Web;

public class MyHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {

        HttpResponse resp = context.Response;
        HttpRequest req = context.Request;

        string basePath = HttpRuntime.AppDomainAppPath;

        string body = File.ReadAllText(basePath + "body.txt");

        string[] param = new string[0]; 

        string result = req.Url.LocalPath;

        param = result.Split('/');

        if (param.Length == 4)
        {
            string a = param[1];
            string b = param[2];
            string c = param[3];

            result = Calculator.Calculate(a, b, c);
        }
        else
        {
            result = "Wrong parametrs";
        }

        string output = String.Format(body, result);

        resp.Write(output);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}