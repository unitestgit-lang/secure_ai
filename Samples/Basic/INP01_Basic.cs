using System;
using System.Web;

public class CommentRenderer
{
    public string RenderComment(string userComment)
    {
        return "<div class='comment'>" + userComment + "</div>";
    }

    public void ShowGreeting(System.Web.HttpResponse response, string name)
    {
        response.Write("<h1>Hello " + name + "</h1>");
    }
}