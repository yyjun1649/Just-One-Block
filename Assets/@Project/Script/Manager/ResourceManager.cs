using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public enum Enum_IconType
{
    Land
}

public class ResourceManager : SingletonBehaviour<ResourceManager>
{
    [SerializeField] private SpriteAtlas _atlasSprite;
    
    private Dictionary<int, Sprite> _landSpriteDict = new Dictionary<int, Sprite>();
    
     private Dictionary<int, Sprite> GetDictionary(Enum_IconType type)
    {
        Dictionary<int, Sprite> dictionary = null;
        switch (type)
        {
            case Enum_IconType.Land:
                dictionary = _landSpriteDict;
                break;
            default:
                break;
        }

        return dictionary;
    }
     
     private string GetIconKey(Enum_IconType type, int index)
    {
        switch (type)
        {
            case Enum_IconType.Land:
                return $"Land_{index}";

            default:
                return string.Empty;
        }
    }
    
     public Sprite GetIconSprite(Enum_IconType type, int index)
     {
         var dictionary = GetDictionary(type);
         var atlas = _atlasSprite; //GetAtlas(type);

         if (!dictionary.TryGetValue(index, out var sprite))
         {
             var key = GetIconKey(type, index);
             sprite = atlas.GetSprite(key);

             dictionary.Add(index, sprite);
         }

         return sprite;
     }
     
    public Sprite GetIconSprite(Enum_IconType type, string spriteName)
    {
        var dictionary = GetDictionary(type);
        var atlas = _atlasSprite;

        var hashCode = spriteName.GetHashCode();

        if (!dictionary.TryGetValue(hashCode, out var sprite))
        {
            sprite = atlas.GetSprite(spriteName);
            dictionary.Add(hashCode, sprite);
        }

        return sprite;
    }
}
