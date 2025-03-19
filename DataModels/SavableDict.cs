using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavableDictionary<TKey, TValue> : ISavable
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();

    private Dictionary<TKey, TValue> data = new Dictionary<TKey, TValue>();

    public void Add(TKey key, TValue value)
    {
        if (!data.ContainsKey(key))
        {
            data[key] = value;
            keys.Add(key);
            values.Add(value);
        }
    }

    public TValue Get(TKey key)
    {
        return data.ContainsKey(key) ? data[key] : default;
    }

    public string SaveToJson()
    {
        keys.Clear();
        values.Clear();
        foreach (var kvp in data)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
        data.Clear();
        for (int i = 0; i < keys.Count; i++)
        {
            data[keys[i]] = values[i];
        }
    }

    public Dictionary<TKey, TValue> ToDictionary()
    {
        return new Dictionary<TKey, TValue>(data);
    }

    public void FromDictionary(Dictionary<TKey, TValue> dict)
    {
        data.Clear();
        keys.Clear();
        values.Clear();

        foreach (var kvp in dict)
        {
            data[kvp.Key] = kvp.Value;
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

}
