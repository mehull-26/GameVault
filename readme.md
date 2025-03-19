# GameVault - Universal Save System for Unity

GameVault is a **modular, scalable, and flexible save system** for Unity. It supports **Registry, Local (File-Based), and Cloud Save Systems**, with built-in **encryption, slot-based saves, and dictionary/list serialization**.

## 🌟 Features

- **Multiple Save Systems**: Registry, Local File, and Cloud (planned).
- **Encryption Support**: AES-based encryption for local saves.
- **Slot-Based Saving**: Manage multiple save slots efficiently.
- **Dictionary & List Serialization**: Handles nested structures within save data.
- **Singleton-Based Architecture**: Ensures a single access point for game-wide data.
- **Customizable Save Paths**: Users can set custom save directories.

## 🛠️ Installation

1. **Download & Import**: Clone or download the repository and add it to your Unity project.
2. **Attach GameVault**: Add the `GameVault` script to an empty GameObject in your main menu scene.
3. **Initialize & Use**:
   ```csharp
   GameVault.factory.RegSaveSystem.Save("playerName", "John Doe");
   string playerName = GameVault.factory.RegSaveSystem.Load<string>("playerName");
   ```

## 🔥 Usage Guide

### ✅ Saving & Loading Data

```csharp
GameVault.factory.LocalSaveSystem.Save("slot1", playerData);
PlayerData loadedData = GameVault.factory.LocalSaveSystem.Load<PlayerData>("slot1");
```

### ✅ Using Savable Dictionary

```csharp
SavableDictionary<string, int> inventory = new SavableDictionary<string, int>();
inventory.Add("gold", 100);
string json = inventory.SaveToJson();

SavableDictionary<string, int> loadedInventory = new SavableDictionary<string, int>();
loadedInventory.LoadFromJson(json);
```

## 🔒 Encryption Utility

Encrypt and decrypt data securely:

```csharp
string encrypted = EncryptionUtility.Encrypt("SecretData", "YourEncryptionKey");
string decrypted = EncryptionUtility.Decrypt(encrypted, "YourEncryptionKey");
```

## 🗂️ File Structure

```
📦 GameVault
 ┣ 📂 Core
 ┃ ┣ 📜 GameVault.cs
 ┃ ┣ 📜 GameVaultSettings.cs
 ┃ ┗ 📜 FileHandler.cs
 ┣ 📂 SaveSystems
 ┃ ┣ 📜 RegistrySave.cs
 ┃ ┣ 📜 LocalSave.cs
 ┃ ┗ 📜 CloudSave.cs (Planned)
 ┣ 📂 Utilities
 ┃ ┗ 📜 EncryptionUtility.cs
 ┗ 📂 DataModels
   ┣ 📜 ISavable.cs
   ┣ 📜 SavableData.cs
   ┗ 📜 SavableDictionary.cs
```

## 🏗️ Future Improvements

- **Cloud Save Integration**.
- **Auto-Save Helper Module**.
- **Support for Binary Serialization (Performance Boost)**.

## 🛠️ Contributing

Feel free to **open issues, suggest features, or contribute** to the repository!

## 📜 License

MIT License - Free to use and modify.

---

GameVault - Making game saves seamless & flexible! 🚀
