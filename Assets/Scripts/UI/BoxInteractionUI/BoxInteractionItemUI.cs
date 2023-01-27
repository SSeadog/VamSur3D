using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoxInteractionItemUI : MonoBehaviour
{
    // Todo
    // �����͸� �޾Ƽ� �����ϱ�
    // Ŭ�� �̺�Ʈ ����

    Image _itemImage;
    TMP_Text _itemName;
    TMP_Text _itemRank;
    TMP_Text _itemDesc;
    TMP_Text _nextLevelText;
    TMP_Text _levelOptionText;

    Button _button;

    public void Init()
    {
        _itemImage = transform.Find("ItemImage").GetComponent<Image>();
        _itemName = transform.Find("ItemNameText").GetComponent<TMP_Text>();
        _itemRank = transform.Find("ItemRankText").GetComponent<TMP_Text>();
        _itemDesc = transform.Find("ItemDescText").GetComponent<TMP_Text>();
        _nextLevelText = transform.Find("NextLevelText").GetComponent<TMP_Text>();
        _levelOptionText = transform.Find("LevelOptionText").GetComponent<TMP_Text>();

        _button = GetComponent<Button>();

        string testUrl = "";
        string testName = "test";
        string testRank = "testR";
        string testDesc = "test test test test test";
        int testNextLevel = 1;
        string testNextLevelOption = "test";

        SetData(testUrl, testName, testRank, testDesc, testNextLevel, testNextLevelOption);

        UnityAction action = () => { Debug.Log("���� ������ Ŭ��!"); };
        SetClickEvent(action);
    }

    void Start()
    {
        //Init();
    }

    void SetData(string imageUrl, string itemName, string itemRank, string itemDesc, int nextLevel, string nextlevelOption)
    {
        // �̹���. ���߿�

        // �̸�
        _itemName.text = itemName;
        // ���
        _itemRank.text = itemRank;
        // ����
        _itemDesc.text = itemDesc;
        // ����
        _nextLevelText.text = "Level " + nextLevel.ToString();
        // ���� �ɼ�
        _levelOptionText.text = nextlevelOption;
    }

    void SetClickEvent(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
}
