using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    UIManager uIManager;

    void Start()
    {
        Managers.Game.playerWeaponLevels = new Dictionary<Define.WeaponType, int>();
        Managers.Game.playerWeaponLevels[Define.WeaponType.Sword] = 1;
        Managers.Game.playerWeaponLevels[Define.WeaponType.Staff] = 1;
        Managers.Game.playerWeaponLevels[Define.WeaponType.Bible] = 1;
        Managers.Game.playerWeaponLevels[Define.WeaponType.FireField] = 1;

        List<Define.WeaponType> weaponTypes = new List<Define.WeaponType>(Managers.Game.playerWeaponLevels.Keys);

        uIManager = GameObject.Find("UIRoot").GetComponent<UIManager>();

        for (int i = 0; i < weaponTypes.Count; i++)
        {
            LoadWeapon(Managers.Data.GetWeaponInfo(weaponTypes[i], Managers.Game.playerWeaponLevels[weaponTypes[i]]));
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
