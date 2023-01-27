using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxInteractionUI : MonoBehaviour
{
    // Todo
    // ���� ������ �ε��ϴ� ���� ����
    // ���� �ݴ� �Լ� ����

    GameObject _subitemRoot;
    GameObject _subItem;

    public void Init()
    {
        _subitemRoot = transform.Find("Panel").gameObject;
        _subItem = Resources.Load<GameObject>("Prefabs/UI/BoxInteractionUI/BoxInteractionItemUI");

        // test�� 3���� ����
        for (int i = 0; i < 3; i++)
        {
            MakeSubItem();
        }
    }

    void Start()
    {
        Init();
    }

    public void Open()
    {
        // active true
        // subItem �ε�
    }

    public void Close()
    {
        // active false
        // subItem ����
    }

    void MakeSubItem()
    {
        GameObject instance = Instantiate(_subItem, _subitemRoot.transform);
        BoxInteractionItemUI boxInteractionItemUI = instance.GetComponent<BoxInteractionItemUI>();
        boxInteractionItemUI.Init();
    }
}
