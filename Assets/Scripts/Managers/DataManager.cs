using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager
{
    private Dictionary<Define.HeroType, Define.Hero> heroDict;

    private Dictionary<Define.WeaponType, Dictionary<int, Define.Weapon>> weaponDict;
    private Dictionary<Define.WeaponType, int> currentWeaponInhenceDict;

    private Dictionary<Define.MonsterType, Define.Monster> monsterDict;

    public void Init()
    {
        // 캐릭터 정보 로드
        heroDict = Util.LoadJsonDict<Define.HeroType, Define.Hero>("Data/HeroData");

        // 무기 정보 로드
        weaponDict = Util.LoadJsonDict<Define.WeaponType, Dictionary<int, Define.Weapon>>("Data/WeaponData");
        currentWeaponInhenceDict = Util.LoadJsonDict<Define.WeaponType, int>("Data/CurrentWeaponInhenceData");

        //몬스터 정보 로드
        monsterDict = Util.LoadJsonDict<Define.MonsterType, Define.Monster>("Data/MonsterData");
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

    public Define.Monster GetMonsterInfo(Define.MonsterType monsterType)
    {
        return monsterDict[monsterType];
    }
}
