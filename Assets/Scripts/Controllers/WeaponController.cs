using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    GameObject _weaponRoot;

    public Dictionary<Define.WeaponType, int> curPlayerWeapons;

    void Start()
    {
        FindWeaponRoot();

        curPlayerWeapons = new Dictionary<Define.WeaponType, int>();
        curPlayerWeapons[Define.WeaponType.Sword] = 3;
        curPlayerWeapons[Define.WeaponType.Staff] = 3;

        ;

        LoadWeapon(MainGameManager.Instance.weaponDict["Sword"][curPlayerWeapons[Define.WeaponType.Sword]]);
        LoadWeapon(MainGameManager.Instance.weaponDict["Staff"][curPlayerWeapons[Define.WeaponType.Staff]]);
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
                break;
            case Define.WeaponType.Staff:
                gameObject.AddComponent<Staff>().Init(weaponData);
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
