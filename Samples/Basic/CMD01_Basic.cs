using System.Diagnostics;

public class PingTool
{
    public void Ping(string host)
    {
        var psi = new ProcessStartInfo("cmd.exe", "/c ping " + host);
        Process.Start(psi);
    }
}