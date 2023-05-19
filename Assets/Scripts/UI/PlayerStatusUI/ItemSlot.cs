using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public bool isFilled = false;

    private string _itemImagePath;
    private Image _itemImage;
    
    public void Init()
    {
        _itemImage = transform.Find("Item").GetComponent<Image>();

        Sprite sprite = Resources.Load<Sprite>(_itemImagePath);
        _itemImage.sprite = sprite;
    }

    public void SetItem(string imagePath)
    {
        isFilled = true;
        _itemImagePath = imagePath;
    }

    void Start()
    {
        Init();
    }
}
