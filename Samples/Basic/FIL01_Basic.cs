using System.IO;

public class FileUploader
{
    public void SaveFile(string fileName, byte[] content)
    {
        string path = Path.Combine("C:\\uploads", fileName);
        File.WriteAllBytes(path, content);
    }

    public string ReadFile(string fileName)
    {
        return File.ReadAllText("C:\\uploads\\" + fileName);
    }
}