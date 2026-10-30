using System;
using System.IO;
using System.Linq;

public class FileUploader
{
    private static readonly string UploadDir = Path.GetFullPath("C:\\uploads");
    private static readonly string[] Allowed = { ".jpg", ".png", ".pdf" };
    private const int MaxBytes = 5 * 1024 * 1024;

    public void SaveFile(string fileName, byte[] content)
    {
        if (content == null || content.Length > MaxBytes)
            throw new ArgumentException("Invalid size");

        string ext = Path.GetExtension(fileName).ToLowerInvariant();
        if (!Allowed.Contains(ext))
            throw new ArgumentException("File type not allowed");

        string safeName = Guid.NewGuid() + ext;
        string fullPath = Path.GetFullPath(Path.Combine(UploadDir, safeName));

        if (!fullPath.StartsWith(UploadDir, StringComparison.OrdinalIgnoreCase))
            throw new UnauthorizedAccessException("Path traversal detected");

        File.WriteAllBytes(fullPath, content);
    }
}