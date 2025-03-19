public interface ISavable
{
    string SaveToJson();  // Convert object to JSON string
    void LoadFromJson(string json);  // Load object from JSON string
}
