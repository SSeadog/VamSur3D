using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    UIManager uIManager;

    void Start()
    {
        GenericSingleton<GameManager>.getInstance().playerWeaponLevels = new Dictionary<Define.WeaponType, int>();
        GenericSingleton<GameManager>.getInstance().playerWeaponLevels[Define.WeaponType.Boomerang] = 3;

        List<Define.WeaponType> weaponTypes = new List<Define.WeaponType>(GenericSingleton<GameManager>.getInstance().playerWeaponLevels.Keys);

        uIManager = GameObject.Find("UIRoot").GetComponent<UIManager>();

        for (int i = 0; i < weaponTypes.Count; i++)
        {
            LoadWeapon(GenericSingleton<DataManager>.getInstance().GetWeaponInfo(weaponTypes[i], GenericSingleton<GameManager>.getInstance().playerWeaponLevels[weaponTypes[i]]));
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
        GenericSingleton<UIManager>.getInstance().GetUI<PlayerStatusUI>().AddItem(weaponData);
    }
}
