using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlots : MonoBehaviour
{
    // ĭ�� �̸� �� �־���ϰ�
    // ��ĭ�� null�� �ΰ�
    ItemSlot[] _items = new ItemSlot[6];

    void Start()
    {
        Init();
    }

    public void Init()
    {
        GenerateSlots();
        // �ӽ÷� 6�� �� �־�α�
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
