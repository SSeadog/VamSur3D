using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public bool isFilled = false;

    string _itemImagePath;
    Image _itemImage;
    
    public void Init()
    {
        _itemImage = transform.Find("Item").GetComponent<Image>();
    }

    public void SetItem(string imagePath)
    {
        isFilled = true;
        _itemImagePath = imagePath;

        Sprite sprite = Resources.Load<Sprite>(_itemImagePath);
        _itemImage.sprite = sprite;
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }
}
