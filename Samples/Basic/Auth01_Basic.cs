using System;
using System.Security.Cryptography;
using System.Text;

public class AuthService
{
    private const string AdminPassword = "Admin@123";

    public string HashPassword(string password)
    {
        using var md5 = MD5.Create();
        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hash);
    }

    public bool Login(string username, string password)
    {
        return username == "admin" && password == AdminPassword;
    }
}