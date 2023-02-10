using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    string _itemImagePath;

    Image _itemImage;
    
    public void Init()
    {
        _itemImage = transform.Find("Item").GetComponent<Image>();
    }

    public void SetItem(string imagePath)
    {
        _itemImagePath = imagePath;

        Sprite sprite = Resources.Load<Sprite>(_itemImagePath);
        _itemImage.sprite = sprite;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
