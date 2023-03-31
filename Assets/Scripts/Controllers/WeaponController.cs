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
        Managers.Game.playerWeaponLevels[Define.WeaponType.Sword] = 3;
        Managers.Game.playerWeaponLevels[Define.WeaponType.Staff] = 3;
        Managers.Game.playerWeaponLevels[Define.WeaponType.Bible] = 3;
        Managers.Game.playerWeaponLevels[Define.WeaponType.FireField] = 3;

        List<Define.WeaponType> weaponTypes = new List<Define.WeaponType>(Managers.Game.playerWeaponLevels.Keys);

        uIManager = GameObject.Find("UIRoot").GetComponent<UIManager>();

        for (int i = 0; i < weaponTypes.Count; i++)
        {
            LoadWeapon(Managers.Data.GetWeaponInfo(weaponTypes[i], Managers.Game.playerWeaponLevels[weaponTypes[i]]));
        }
    }

    public void LoadWeapon(Define.Weapon weaponData)
    {
        Define.WeaponType weaponType = (Define.WeaponType)weaponData.id;
        System.Type type = System.Type.GetType(weaponType.ToString());

        Component beforeWeapon = gameObject.GetComponent(type);
        if (beforeWeapon != null)
            Destroy(beforeWeapon);

        var weapon = gameObject.AddComponent(type);
        if (weapon is WeaponBase)
            ((WeaponBase)weapon).Init(weaponData);
        uIManager.playerStatusUI.AddItem(weaponData);
    }
}
