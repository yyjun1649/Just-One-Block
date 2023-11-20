using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler,IEndDragHandler
{
    private bool isDragging = false;
    private Vector2 originalPosition;
    public float gridSize = 1.1f; // 그리드 셀 크기
    public GameObject transparentBlockPrefab; // 반투명 블록 프리팹
    private GameObject currentTransparentBlock;
    
    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            
            if (currentTransparentBlock == null)
            {
                currentTransparentBlock = transparentBlockPrefab;
                transparentBlockPrefab.SetActive(true);
            }
            
            currentTransparentBlock.transform.position = SnapToGrid(mousePos);
        }
        else
        {
            if (currentTransparentBlock != null)
            {
                transparentBlockPrefab.SetActive(false);
                currentTransparentBlock = null;
            }
        }
    }
    
    private Vector2 SnapToGrid(Vector3 pos)
    {
        float x = Mathf.Round(pos.x / gridSize) * gridSize;
        float y = Mathf.Round(pos.y / gridSize) * gridSize;
        return new Vector2(x, y);
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }

    public void SetPosition(Vector3 vector3)
    {
        transform.position = vector3;
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragAndDropHandler.Grap(this.gameObject);
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }
}