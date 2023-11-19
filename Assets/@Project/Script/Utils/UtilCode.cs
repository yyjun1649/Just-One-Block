using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;


public static class UtilCode
{
    public static DateTime UnixTimeToDateTime(long unixTime)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0); 
        
        return origin.AddSeconds(unixTime);
    }
    
    public static bool GetChance(double chance)
    {
        if (chance <= 0) return false;
        if (chance >= 100) return true;
        
        var randomFloatValue = UnityEngine.Random.Range(0f, 100f);
        
        return chance >= randomFloatValue;
    }
    
    public static bool GetChance(float chance)
    {
        if (chance <= 0) return false;
        if (chance >= 100) return true;
        
        var randomFloatValue = UnityEngine.Random.Range(0f, 100f);
        
        return chance >= randomFloatValue;
    }

    public static bool GetChance(int chance)
    {
        if (chance <= 0) return false;
        if (chance >= 100) return true;

        var randomIntValue = UnityEngine.Random.Range(0, 101);

        return chance >= randomIntValue;
    }

    public static int GetWeightChance(List<int> chance)
    {
        float sum = 0;
        
        for(int i = 0 ; i < chance.Count ; i++)
        {
            sum += chance[i];
        }

        float randomFloat = Random.Range(0, sum);
        
        sum = 0;

        for (var i = 0; i < chance.Count; i++)
        {
            sum += chance[i];
    
            if (randomFloat <= sum)
            {
                return i;
            }
        }

        return 0;
    }

    public static Dictionary<T, int> ListToDictionary<T>(List<T> list)
    {
        Dictionary<T, int> dictionary = new Dictionary<T, int>(list.Count / 2);

        foreach (T item in list)
        {
            if (!dictionary.ContainsKey(item))
            {
                dictionary[item] = 1;
            }
            else
            {
                dictionary[item]++;
            }
        }

        return dictionary;
    }
    
    public static float Approach(float from, float to, float amount)
    {
        if (from < to)
        {
            from += amount;

            if (from > to)
            {
                return to;
            }
        }
        else
        {
            from -= amount;

            if (from < to)
            {
                return to;
            }
        }

        return from;
    }

    public static double Sigma(double n, int power)
    {
        if (power == 1)
        {
            return (n * (n + 1))  * 0.5f;
        }
        else if (power == 2)
        {
            return (n * (n + 1) * (2 * n + 1)) / 6;
        }
        else if (power == 3)
        {
            var a = (n * (n + 1));
            return a * a * 0.25f;
        }
        else if (power == 4)
        {
            return n * (n + 1) * (2 * n + 1) * (3 * n * n + 3 * n - 1) / 30;
        }
        
        return 0;
    }

    public static bool IsTablet()
    {
        float width = Screen.width;
        float height = Screen.height;
        
        return width / height >= 0.65f;
    }
    
    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;  
        while (n > 1) {  
            n--;
            int k = UnityEngine.Random.Range(0, n);
            (list[k], list[n]) = (list[n], list[k]);
        } 
    }
    
    public static void ExpandListItem<T>(this List<T> list, int requireCount, Action<T> expandItemCallback = null) where T : new()
    {
        list ??= new List<T>();

        for (int i = list.Count; i < requireCount; i++)
        {
            T item = new T();
            list.Add(item);
            
            expandItemCallback?.Invoke(item);
        }
    }

    public static void AddEventTriggerListener(this EventTrigger trigger, EventTriggerType triggerType, UnityAction<BaseEventData> callback)
    {
        if(trigger == null)
        {
            return;
        }

        EventTrigger.Entry entry = new();
        entry.eventID = triggerType;
        entry.callback.AddListener(callback);

        trigger.triggers.Add(entry);
    }

    public static void RemoveEventTriggerListener(this EventTrigger trigger, EventTriggerType triggerType, UnityAction<BaseEventData> callback)
    {
        if(trigger == null)
        {
            return;
        }

        EventTrigger.Entry entry = trigger.triggers.Find(e => e.eventID == triggerType);
        entry?.callback.RemoveListener(callback);
    }
}