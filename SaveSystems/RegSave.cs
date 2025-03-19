using UnityEngine;

public class RegistrySave : IDataSaveSystem
{
    public void Save<T>(string key, T data)
    {
        if (data is int) PlayerPrefs.SetInt(key, (int)(object)data);
        else if (data is float) PlayerPrefs.SetFloat(key, (float)(object)data);
        else if (data is string) PlayerPrefs.SetString(key, (string)(object)data);
        else
        {
            Debug.LogError($"RegSave Error: Type {typeof(T)} not supported!");
            return;
        }

        PlayerPrefs.Save();
    }

    public T Load<T>(string key, T defaultValue = default)
    {
        if (!PlayerPrefs.HasKey(key)) return defaultValue;

        if (typeof(T) == typeof(int)) return (T)(object)PlayerPrefs.GetInt(key);
        if (typeof(T) == typeof(float)) return (T)(object)PlayerPrefs.GetFloat(key);
        if (typeof(T) == typeof(string)) return (T)(object)PlayerPrefs.GetString(key);

        Debug.LogError($"RegLoad Error: Type {typeof(T)} not supported!");
        return defaultValue;
    }

    public bool HasKey(string key) => PlayerPrefs.HasKey(key);
    public void Delete(string key) => PlayerPrefs.DeleteKey(key);
}
