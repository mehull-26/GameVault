GameVault supports two types of save systems currently.

- Registry based save system using PlayerPrefs
- Local save system used optionally encrypted JSON files

### **1. Registry Save System**

Use user’s platform registry for lightweight and quick storage.
Only supports three datatypes:

- String
- Float
- Int

#### **Saving Data**

```csharp
GameVault.factory.RegSaveSystem.Save("volume", 0.8f);
```

#### **Loading Data**

```csharp
float volume = GameVault.factory.RegSaveSystem.Load<float>("volume", 1.0f);
```

---

### **3. Local Save System (File-Based)**

Use JSON files to store structured data.

#### **Saving Data**

First you need to create datamodel making sure, it inherits from **SavableData** and is marked **[System.Serializable]**.

```csharp
[System.Serializable]
public class datamodel : SavableData
{
    public int gold;
    public int exilir;
    public SavableDictionary<string, string> clothes = new SavableDictionary<string, string>();
    public SavableDictionary<int, string> weapons = new SavableDictionary<int, string>();
}
```

#### **Saving Data**

Default slot is `_global_`

```csharp
GameVault.factory.LocalSaveSystem.Save(SavableData datamodel, string slot);
```

#### **Loading Data**

```csharp
PlayerData data = GameVault.factory.LocalSaveSystem.Load<datamodel>(string slot);
```

---

### **4. Data Structures**

GameVault supports primitive types, dictionaries, and custom serializable classes.

#### **Savable Dictionary Example**

SaveToJson only converts the dictionary to JSON.

```csharp
SavableDictionary<string, int> scores = new SavableDictionary<string, int>();
scores.Add("level1", 100);
string json = scores.SaveToJson();
```

#### **Loading a Dictionary**

```csharp
SavableDictionary<string, int> loadedScores = new SavableDictionary<string, int>();
loadedScores.LoadFromJson(json);
```

---

### **5. Encryption Support**

GameVault uses AES encryption for secure file storage.

#### **Enabling Encryption**

```csharp
GameVault.factory.Settings.EnableEncryption = true;
```

#### **Custom Encryption Key**

```csharp
GameVault.factory.Settings.EncryptionKey = "MySecretKey123";
```

---

## Notes

- Ensure `GameVault` is initialized before use.
- Registry Save is platform-dependent.
- Local Save System requires read/write permissions.

---

## Conclusion

GameVault provides a simple, secure, and scalable way to manage game saves in Unity.
