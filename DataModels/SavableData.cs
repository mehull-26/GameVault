using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class SavableData : ISavable
{
    public virtual string SaveToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public virtual void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
        AutoFixSavableDictionaries();
    }

    private void AutoFixSavableDictionaries()
    {
        Type type = this.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (field.FieldType.IsGenericType &&
                field.FieldType.GetGenericTypeDefinition() == typeof(SavableDictionary<,>))
            {
                var savableDict = field.GetValue(this) as ISavable;
                if (savableDict != null)
                {
                    savableDict.LoadFromJson(SaveToJson()); // Re-run JSON loading on it
                }
            }
        }
    }
}
