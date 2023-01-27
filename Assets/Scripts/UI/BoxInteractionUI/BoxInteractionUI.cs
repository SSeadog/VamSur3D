using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxInteractionUI : MonoBehaviour
{
    // Todo
    // 서브 아이템 로드하는 로직 생성
    // 열고 닫는 함수 생성

    GameObject _subitemRoot;
    GameObject _subItem;

    public void Init()
    {
        _subitemRoot = transform.Find("Panel").gameObject;
        _subItem = Resources.Load<GameObject>("Prefabs/UI/BoxInteractionUI/BoxInteractionItemUI");

        // test로 3개만 생성
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
        // subItem 로드
    }

    public void Close()
    {
        // active false
        // subItem 삭제
    }

    void MakeSubItem()
    {
        GameObject instance = Instantiate(_subItem, _subitemRoot.transform);
        BoxInteractionItemUI boxInteractionItemUI = instance.GetComponent<BoxInteractionItemUI>();
        boxInteractionItemUI.Init();
    }
}
