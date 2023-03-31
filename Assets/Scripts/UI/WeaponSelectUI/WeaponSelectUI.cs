using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSelectUI : MonoBehaviour
{
    // Todo
    // subItem ���� �����͸� �޾Ƽ� �ε�

    GameObject _subitemRoot;
    GameObject _subItem;

    List<WeaponSelectItemUI> _subItems;

    public void Init()
    {
        _subitemRoot = transform.Find("Panel").gameObject;
        _subItem = Resources.Load<GameObject>("Prefabs/UI/WeaponSelectUI/WeaponSelectItemUI");

        _subItems = new List<WeaponSelectItemUI>();
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

        Time.timeScale = 0f;
    }

    public void Close()
    {
        // active false
        gameObject.SetActive(false);

        // subItem ����
        for (int i = 0; i < _subItems.Count; i++)
            Destroy(_subItems[i].gameObject);
        _subItems.Clear();

        Time.timeScale = 1f;
    }

    void MakeSubItem()
    {
        // �������� ���� �� �ִ� weapon �̱�
        // �ߺ��� ���ϰ�
        // weapon ���� ����
        // Boomerang ���� �ȸ��� ����
        Define.WeaponType randomWeaponType = (Define.WeaponType)Random.Range((int)Define.WeaponType.None + 1, (int)Define.WeaponType.Boomerang);
        //while (true)
        //{
        //    bool isUnique = true;
        //    foreach (WeaponSelectItemUI item in _subItems)
        //    {
        //        if (item.weaponInfo.id == (int)randomWeaponType)
        //            isUnique = false;
        //    }

        //    if (isUnique)
        //        break;
        //}

        int randomWeaponLevel = Managers.Game.playerWeaponLevels.ContainsKey(randomWeaponType) ? Managers.Game.playerWeaponLevels[randomWeaponType] + 1 : 1;
        Define.Weapon weapon = Managers.Data.GetWeaponInfo(randomWeaponType, randomWeaponLevel);

        GameObject instance = Instantiate(_subItem, _subitemRoot.transform);
        WeaponSelectItemUI weaponSelectItemUI = instance.GetComponent<WeaponSelectItemUI>();
        _subItems.Add(weaponSelectItemUI);
        weaponSelectItemUI.Init(weapon);
    }
}
