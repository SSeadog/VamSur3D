using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlots : MonoBehaviour
{
    // 칸은 미리 다 있어야하고
    // 빈칸은 null로 두고
    ItemSlot[] _items = new ItemSlot[6];

    void Start()
    {
        Init();
    }

    public void Init()
    {
        GenerateSlots();
        // 임시로 6개 다 넣어두기
    }

    void GenerateSlots()
    {
        string imagePath = "Prefabs/Textures/UI/icon/DrakBrown/sword";

        GameObject slotOriginal = Resources.Load<GameObject>("Prefabs/UI/PlayerStatusUI/ItemSlot");
        for (int i = 0; i < _items.Length; i++)
        {
            GameObject slotInstance = Instantiate<GameObject>(slotOriginal, transform);
            ItemSlot itemSlot = slotInstance.GetComponent<ItemSlot>();
            itemSlot.Init();
            itemSlot.SetItem(imagePath);

            _items[i] = itemSlot;
        }
    }

    public void AddItem()
    {

    }
}
