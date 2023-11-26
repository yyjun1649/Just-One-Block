using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LandReward : MonoBehaviour
{
    [SerializeField] private Image _imageReward;
    [SerializeField] private TextMeshProUGUI _txtRewardCount;
    [SerializeField] private CanvasGroup _canvasGroup;

    private Vector3 startPos;
    
    private void Start()
    {
        startPos = transform.position;
        gameObject.SetActive(false);
    }

    public void Initialize(int id, int count)
    {
        if (id < 0)
        {
            return;
        }
        
        _imageReward.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Land, id);
        _txtRewardCount.text = $"+{count}";
        transform.position = startPos;
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1;
        
        transform.DOMoveY(startPos.y+0.25f, 2f);
        _canvasGroup.DOFade(0f, 2f);
    }
}
