// Datamodel of Invetory
// Can use any custom datamodel for saving and loading
// It needs to be System.Serializable and of should inherit from SavableData

[System.Serializable]
public class Inventory : SavableData
{
    public int gold;
    public int exilir;
    public SavableDictionary<string, string> clothes = new SavableDictionary<string, string>();
    public SavableDictionary<int, string> weapons = new SavableDictionary<int, string>();
}

