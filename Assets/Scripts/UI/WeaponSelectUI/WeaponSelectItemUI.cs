using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponSelectItemUI : MonoBehaviour
{
    // Todo
    // �����͸� �޾Ƽ� �����ϱ�
    // Ŭ�� �̺�Ʈ ����

    public Define.Weapon weaponInfo;

    Image _itemImage;
    TMP_Text _itemName;
    TMP_Text _itemRank;
    TMP_Text _itemDesc;
    TMP_Text _nextLevelText;
    TMP_Text _levelOptionText;

    Button _button;

    public void Init(Define.Weapon weaponInfo)
    {
        this.weaponInfo = weaponInfo;
        _itemImage = transform.Find("ItemImage").GetComponent<Image>();
        _itemName = transform.Find("ItemNameText").GetComponent<TMP_Text>();
        _itemRank = transform.Find("ItemRankText").GetComponent<TMP_Text>();
        _itemDesc = transform.Find("ItemDescText").GetComponent<TMP_Text>();
        _nextLevelText = transform.Find("NextLevelText").GetComponent<TMP_Text>();
        _levelOptionText = transform.Find("LevelOptionText").GetComponent<TMP_Text>();

        _button = GetComponent<Button>();

        string testUrl = "";
        string testName = ((Define.WeaponType) weaponInfo.id).ToString();
        string testRank = "testR";
        string testDesc = "test test test test test";
        int testNextLevel = weaponInfo.lv;
        string testNextLevelOption = "test";

        SetData(testUrl, testName, testRank, testDesc, testNextLevel, testNextLevelOption);

        UnityAction action = () =>
        {
            Debug.Log($"{(Define.WeaponType)weaponInfo.id} {weaponInfo.lv}");
            Managers.Game.playerWeaponLevels[(Define.WeaponType)weaponInfo.id] = weaponInfo.lv;
            Managers.Game.player.GetComponent<WeaponController>().LoadWeapon(weaponInfo);
            Managers.Game.uIManager.weaponSelectUI.Close();
        };

        SetClickEvent(action);
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