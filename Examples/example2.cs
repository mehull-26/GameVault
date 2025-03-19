using System.Collections.Generic;
using UnityEngine;

//This script is attached to player in Scene2

public class tryScript2 : MonoBehaviour
{
    void Start()
    {
        // Everything will be accessible through the GameVault factory instance
        // Settings prvide features of encryption key, enable encryption and custom save directory.
        
        //These are the default setting of GameVault
        GameVault.factory.Settings.EnableEncryption = false;
        GameVault.factory.Settings.EncryptionKey = "DefaultKey";
        GameVault.factory.Settings.SaveDirectory = "GameSaves";


        // This will save settings for your future use
        // You can save multiple settings using different setting slot numbers
        GameVault.factory.Settings.SaveSettings(0);
        // This will load the settings if you have saved them before
        GameVault.factory.Settings.LoadSettings(0);
        // This will print the settings to the console of any given setting slot number
        GameVault.factory.Settings.PrintSettings(0);
        // This will reset the current settings to default
        GameVault.factory.Settings.ResetSettings();

        // LocalSaveSystem
        // Creates a datamodel of Inventory which inherits from ISavable
        Inventory inv = new Inventory();
        inv.gold = 100;
        inv.exilir = 50;
        inv.clothes.Add("t-shirt", "cotton");
        inv.clothes.Add("shirt", "woolen");
        inv.weapons.Add(0, "shield");
        inv.weapons.Add(1, "helmet");

        // Save the Inventory as a JSON string
        GameVault.factory.LocalSaveSystem.Save(inv);

        // Load the Inventory from the JSON string
        Inventory inv2 = GameVault.factory.LocalSaveSystem.Load<Inventory>();

        // Convert them from SavableDictionary<,> to Dictionary if required
        Dictionary<string, string> dict = inv2.clothes.ToDictionary();
        Dictionary<int, string> dict2 = inv2.weapons.ToDictionary();    
    }

    void Update()
    {
        
    }
}


