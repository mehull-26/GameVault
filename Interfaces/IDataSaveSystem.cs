using UnityEngine;

public interface IDataSaveSystem
{
    void Save<T>(string key, T data);
    T Load<T>(string key, T defaultValue = default);
    bool HasKey(string key);
    void Delete(string key);
}