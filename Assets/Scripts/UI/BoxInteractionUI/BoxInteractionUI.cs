using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxInteractionUI : MonoBehaviour
{
    // Todo
    // subItem ���� �����͸� �޾Ƽ� �ε�

    GameObject _subitemRoot;
    GameObject _subItem;

    List<GameObject> _subItems;

    public void Init()
    {
        _subitemRoot = transform.Find("Panel").gameObject;
        _subItem = Resources.Load<GameObject>("Prefabs/UI/BoxInteractionUI/BoxInteractionItemUI");

        _subItems = new List<GameObject>();
    }

    void Start()
    {
        Init();
    }

    public void Open()
    {
        // active true
        gameObject.SetActive(true);

        // subItem �ε� test�� 3���� ����
        for (int i = 0; i < 3; i++)
        {
            MakeSubItem();
        }
    }

    public void Close()
    {
        // active false
        gameObject.SetActive(false);

        // subItem ����
        for (int i = 0; i < _subItems.Count; i++)
            Destroy(_subItems[i]);
        _subItems.Clear();
    }

    void MakeSubItem()
    {
        GameObject instance = Instantiate(_subItem, _subitemRoot.transform);
        _subItems.Add(instance);
        BoxInteractionItemUI boxInteractionItemUI = instance.GetComponent<BoxInteractionItemUI>();
        boxInteractionItemUI.Init();
    }
}
