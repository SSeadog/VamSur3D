using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    GameObject _weaponRoot;

    public Dictionary<Define.WeaponType, int> curPlayerWeaponLevels;

    UIManager uIManager;

    void Start()
    {
        FindWeaponRoot();

        curPlayerWeaponLevels = new Dictionary<Define.WeaponType, int>();
        curPlayerWeaponLevels[Define.WeaponType.Sword] = 3;
        curPlayerWeaponLevels[Define.WeaponType.Staff] = 3;

        List<Define.WeaponType> weaponTypes = new List<Define.WeaponType>(curPlayerWeaponLevels.Keys);

        uIManager = GameObject.Find("UIRoot").GetComponent<UIManager>();

        for (int i = 0; i < weaponTypes.Count; i++)
        {
            LoadWeapon(DataManager.Instance.GetWeaponInfo(weaponTypes[i], curPlayerWeaponLevels[weaponTypes[i]]));
        }
    }

    void FindWeaponRoot()
    {
        foreach (Transform tr in transform.GetComponentInChildren<Transform>())
        {
            if (tr.name == "WeaponRoot")
            {
                _weaponRoot = tr.gameObject;
            }
        }

        if (_weaponRoot == null)
        {
            Debug.Log("WeaponRoot ¾øÀ½");
        }
    }

    public void LoadWeapon(Define.Weapon weaponData)
    {
        switch ((Define.WeaponType)weaponData.id)
        {
            case Define.WeaponType.Sword:
                gameObject.AddComponent<Sword>().Init(weaponData);
                uIManager.playerStatusUI.AddItem(weaponData);
                break;
            case Define.WeaponType.Staff:
                gameObject.AddComponent<Staff>().Init(weaponData);
                uIManager.playerStatusUI.AddItem(weaponData);
                break;
            case Define.WeaponType.Bible:
                break;
            case Define.WeaponType.FireField:
                break;
            case Define.WeaponType.Boomerang:
                break;
        }
    }
}
