using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Dictionary<Define.WeaponType, int> curPlayerWeaponLevels;

    UIManager uIManager;

    void Start()
    {
        curPlayerWeaponLevels = new Dictionary<Define.WeaponType, int>();
        curPlayerWeaponLevels[Define.WeaponType.Sword] = 3;
        curPlayerWeaponLevels[Define.WeaponType.Staff] = 3;
        curPlayerWeaponLevels[Define.WeaponType.Bible] = 3;
        curPlayerWeaponLevels[Define.WeaponType.FireField] = 3;

        List<Define.WeaponType> weaponTypes = new List<Define.WeaponType>(curPlayerWeaponLevels.Keys);

        uIManager = GameObject.Find("UIRoot").GetComponent<UIManager>();

        for (int i = 0; i < weaponTypes.Count; i++)
        {
            LoadWeapon(Managers.Data.GetWeaponInfo(weaponTypes[i], curPlayerWeaponLevels[weaponTypes[i]]));
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
                gameObject.AddComponent<Bible>().Init(weaponData);
                uIManager.playerStatusUI.AddItem(weaponData);
                break;
            case Define.WeaponType.FireField:
                gameObject.AddComponent<FireField>().Init(weaponData);
                uIManager.playerStatusUI.AddItem(weaponData);
                break;
            case Define.WeaponType.Boomerang:
                break;
        }
    }
}
