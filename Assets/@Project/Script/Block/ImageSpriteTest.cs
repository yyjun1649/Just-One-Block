using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpriteTest : MonoBehaviour
{
    [SerializeField] private DragAndDrop _dragAndDrop;
    
    
    public void OnMouseDown()
    {
        DragAndDropHandler.Grap(5);
        _dragAndDrop.OnDrag();
    }

    public void OnMouseUp()
    {
        _dragAndDrop.OnEndDrag();
    }
}
