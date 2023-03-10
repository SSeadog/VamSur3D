using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private Dictionary<Define.HeroType, Define.Hero> heroDict;

    private Dictionary<Define.WeaponType, Dictionary<int, Define.Weapon>> weaponDict;
    private Dictionary<Define.WeaponType, int> currentWeaponInhenceDict;

    public void Init()
    {
        // 캐릭터 정보 로드
        heroDict = Util.LoadJsonDict<Define.HeroType, Define.Hero>("Data/HeroData");

        // 무기 정보 로드
        weaponDict = Util.LoadJsonDict<Define.WeaponType, Dictionary<int, Define.Weapon>>("Data/WeaponData");
        currentWeaponInhenceDict = Util.LoadJsonDict<Define.WeaponType, int>("Data/CurrentWeaponInhenceData");
    }

    public Define.Hero GetHeroInfo(Define.HeroType type)
    {
        return heroDict[type];
    }

    public Define.Weapon GetWeaponInfo(Define.WeaponType weaponType, int level)
    {
        return weaponDict[weaponType][level];
    }

    public int GetWeaponEnhenceLevel(Define.WeaponType weaponType)
    {
        return currentWeaponInhenceDict[weaponType];
    }
}
