using System.IO;
using UnityEngine;

public class FileHandler
{
    private string savePath;

    public FileHandler()
    {
        savePath = GameVault.factory.Settings.SaveDirectory; 
        if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
    }

    public void SaveFile(string fileName, string jsonData)
    {
        string fullPath = Path.Combine(savePath, fileName);
        File.WriteAllText(fullPath, jsonData);
    }

    public string LoadFile(string fileName)
    {
        string fullPath = Path.Combine(savePath, fileName);
        return File.Exists(fullPath) ? File.ReadAllText(fullPath) : null;
    }

    public void DeleteFile(string fileName)
    {
        string fullPath = Path.Combine(savePath, fileName);
        if (File.Exists(fullPath)) File.Delete(fullPath);
    }

    public bool FileExists(string fileName)
    {
        return File.Exists(Path.Combine(savePath, fileName));
    }
}
