using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponSelectItemUI : MonoBehaviour
{
    // Todo
    // 데이터를 받아서 설정하기
    // 클릭 이벤트 설정

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
        string testRank = weaponInfo.rank;
        string testDesc = weaponInfo.desc;
        int testNextLevel = weaponInfo.lv;
        string testNextLevelOption = weaponInfo.levelDesc;

        SetData(testUrl, testName, testRank, testDesc, testNextLevel, testNextLevelOption);

        UnityAction action = () =>
        {
            Debug.Log($"{(Define.WeaponType)weaponInfo.id} {weaponInfo.lv}");
            GenericSingleton<GameManager>.getInstance().playerWeaponLevels[(Define.WeaponType)weaponInfo.id] = weaponInfo.lv;
            GenericSingleton<GameManager>.getInstance().player.GetComponent<WeaponController>().LoadWeapon(weaponInfo);
            GenericSingleton<UIManager>.getInstance().GetUI<WeaponSelectUI>().Close();
        };

        SetClickEvent(action);
    }

    void SetData(string imageUrl, string itemName, string itemRank, string itemDesc, int nextLevel, string nextlevelOption)
    {
        // 이미지. 나중에

        // 이름
        _itemName.text = itemName;
        // 등급
        _itemRank.text = itemRank;
        // 설명
        _itemDesc.text = itemDesc;
        // 레벨
        _nextLevelText.text = "Level " + nextLevel.ToString();
        // 레벨 옵션
        _levelOptionText.text = nextlevelOption;
    }

    void SetClickEvent(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
}
