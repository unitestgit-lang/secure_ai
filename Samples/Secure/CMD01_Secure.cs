using System;
using System.Diagnostics;
using System.Net;

public class PingTool
{
    public void Ping(string host)
    {
        if (!IPAddress.TryParse(host, out _) &&
            Uri.CheckHostName(host) != UriHostNameType.Dns)
            throw new ArgumentException("Invalid host");

        var psi = new ProcessStartInfo("ping")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true
        };
        psi.ArgumentList.Add("-n");
        psi.ArgumentList.Add("2");
        psi.ArgumentList.Add(host);
        Process.Start(psi);
    }
}