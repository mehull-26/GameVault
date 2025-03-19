using UnityEngine;

[System.Serializable]
public class GameVaultSettings
{
    public bool EnableEncryption = false;
    public string SaveDirectory = "GameSaves"; // Default save directory
    public string EncryptionKey = "DefaultKey"; // Encryption key (if enabled)
    public void LoadSettings(int settingsSlot)
    {
        // Load settings from PlayerPrefs (or any other persistent storage)
        EnableEncryption = PlayerPrefs.GetInt("EnableEncryption" + settingsSlot, 0) == 1;
        SaveDirectory = PlayerPrefs.GetString("SaveDirectory" + settingsSlot, "GameSaves");
        EncryptionKey = PlayerPrefs.GetString("EncryptionKey" + settingsSlot, "DefaultKey");
    }

    public void SaveSettings(int settingsSlot)
    {
        // Save settings to PlayerPrefs (or other persistent storage)
        PlayerPrefs.SetInt("EnableEncryption" + settingsSlot, EnableEncryption ? 1 : 0);
        PlayerPrefs.SetString("SaveDirectory" + settingsSlot, SaveDirectory);
        PlayerPrefs.SetString("EncryptionKey" + settingsSlot, EncryptionKey);
        PlayerPrefs.Save();
    }

    public void ResetSettings()
    {
        EnableEncryption = false;
        SaveDirectory = "GameSaves";
        EncryptionKey = "DefaultKey";
    }

    public void PrintSettings(int settingsSlot)
    {
        Debug.Log("EnableEncryption: " + ((PlayerPrefs.GetInt("EnableEncryption" + settingsSlot, 0) == 0 )? "false" : "true") );
        Debug.Log("SaveDirectory: " + SaveDirectory);
        Debug.Log("EncryptionKey: " + EncryptionKey);
    }
}

