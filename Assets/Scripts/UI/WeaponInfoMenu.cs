using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoMenu : MonoBehaviour
{
    [SerializeField] Image _thumbImage;
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _lvText;
    [SerializeField] TMP_Text _descriptionText;
    [SerializeField] TMP_Text _costText;
    [SerializeField] Button _button;
    Define.WeaponType _type;

    public void SetData(Define.WeaponType type)
    {
        _type = type;

        Define.Weapon weaponData = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(_type);
        int curEnhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(_type);
        Define.WeaponEnhanceData enhanceData = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceInfo(_type, curEnhanceLevel);

        Sprite thumb = Instantiate(Resources.Load<Sprite>(weaponData.thumbnailPath));
        _thumbImage.sprite = thumb;
        _nameText.text = _type.ToString();
        _lvText.text = curEnhanceLevel.ToString();
        _descriptionText.text = "Test";
        _costText.text = enhanceData.cost.ToString();
    }
    public void EnhanceWeapon()
    {
        bool result = GenericSingleton<GameManager>.getInstance().UpgradeWeaponEnhanceLevel(_type);

        if (result == true)
        {
            int curEnhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(_type);
            _lvText.text = curEnhanceLevel.ToString();
        }

        Debug.Log($"��ȭ ���� ����: {result} {_type}��ȭ ����: {GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(_type)}");
    }
}