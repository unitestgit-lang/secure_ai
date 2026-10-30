using System;
using System.Net;

public class CommentRenderer
{
    public string RenderComment(string userComment)
    {
        string safe = WebUtility.HtmlEncode(userComment ?? string.Empty);
        return "<div class='comment'>" + safe + "</div>";
    }

    public string BuildGreeting(string name)
    {
        return "<h1>Hello " + WebUtility.HtmlEncode(name ?? string.Empty) + "</h1>";
    }
}