using System;
using System.IO;
using UnityEngine;

public class LocalSave
{
    private FileHandler fileHandler;

    public LocalSave()
    {
        fileHandler = new FileHandler();
    }

    public void Save(SavableData data, string slot = "_global_")
    {
        string json = data.SaveToJson();
        if (GameVault.factory.Settings.EnableEncryption)
            json = EncryptionUtility.Encrypt(json, GameVault.factory.Settings.EncryptionKey);

        fileHandler.SaveFile(slot + ".json", json);
    }

    public T Load<T>(string slot = "_global_") where T : SavableData, new()
    {

        if (!fileHandler.FileExists(slot + ".json"))
        {
            Debug.LogWarning("Save file not found: " + slot + ".json");
            return null;
        }

        string json = fileHandler.LoadFile(slot + ".json");

        if (GameVault.factory.Settings.EnableEncryption)
            json = EncryptionUtility.Decrypt(json, GameVault.factory.Settings.EncryptionKey);

        T data = new T();
        data.LoadFromJson(json);
        return data;
    }

    public void DeleteSave(string slot = "_global_")
    {

        if (fileHandler.FileExists(slot+".json"))
            fileHandler.DeleteFile(slot + ".json");
    }
}
