using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private bool isDragging = false;
    private Vector2 originalPosition;
    private float gridSize = 1.2f; // 그리드 셀 크기

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

            transform.position = SnapToGrid(mousePos);
        }
    }
    
    private Vector2 SnapToGrid(Vector3 pos)
    {
        float x = Mathf.Round(pos.x / gridSize) * gridSize;
        float y = Mathf.Round(pos.y / gridSize) * gridSize;
        return new Vector2(x, y);
    }
    
    public void OnDrag(int id)
    {
        _spriteRenderer.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Land, id);
        isDragging = true;
        gameObject.SetActive(true);
    }

    public void OnEndDrag()
    {
        isDragging = false;
        gameObject.SetActive(false);
    }
}