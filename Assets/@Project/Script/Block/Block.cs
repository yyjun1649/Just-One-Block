using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector2 Position;
    public Enum_BlockType EnumBlockType;
    public int Level;
    public UIBlock blockUI;

    public void SetPoisiton()
    {
        transform.localPosition = Position;
    }

    public void SetBlockSprite()
    {
        
    }

    public void SetLevel()
    {
        
    }

    public void GetReward()
    {
        
    }

    public void OnClickBlock()
    {
        
    }
}
