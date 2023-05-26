using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private Dictionary<Define.HeroType, Define.Hero> _heroDict;
    private Dictionary<Define.WeaponType, Dictionary<int, Define.Weapon>> _weaponDict;
    private Dictionary<Define.WeaponType, List<Define.WeaponEnhanceData>> _weaponEnhanceDict;
    private Dictionary<Define.WeaponType, int> _currentWeaponInhanceDict;
    private Dictionary<Define.MonsterType, Define.Monster> _monsterDict;

    public Dictionary<Define.WeaponType, Dictionary<int, Define.Weapon>> WeaponDict { get { return _weaponDict; } }
    public Dictionary<Define.HeroType, Define.Hero> HeroDict { get { return _heroDict; } }

    void Awake()
    {
        Init();
    }

    void Init()
    {
        // ĳ���� ���� �ε�
        _heroDict = Util.LoadJsonDict<Define.HeroType, Define.Hero>("Data/HeroData");

        // ���� ���� �ε�
        _weaponDict = Util.LoadJsonDict<Define.WeaponType, Dictionary<int, Define.Weapon>>("Data/WeaponData");
        _weaponEnhanceDict = Util.LoadJsonDict<Define.WeaponType, List<Define.WeaponEnhanceData>>("Data/WeaponInhanceData");
        _currentWeaponInhanceDict = Util.LoadJsonDict<Define.WeaponType, int>(Application.persistentDataPath + "/CurrentWeaponInhanceData.json");

        //���� ���� �ε�
        _monsterDict = Util.LoadJsonDict<Define.MonsterType, Define.Monster>("Data/MonsterData");
    }

    public Define.Hero GetHeroInfo(Define.HeroType type)
    {
        return _heroDict[type];
    }

    public Define.Weapon GetWeaponInfo(Define.WeaponType weaponType)
    {
        return GetWeaponInfo(weaponType, 1);
    }

    public Define.Weapon GetWeaponInfo(Define.WeaponType weaponType, int level)
    {
        return _weaponDict[weaponType][level];
    }

    public Define.WeaponEnhanceData GetWeaponEnhanceInfo(Define.WeaponType weaponType, int enhanceLevel)
    {
        return _weaponEnhanceDict[weaponType][enhanceLevel];
    }

    public int GetWeaponEnhanceLevel(Define.WeaponType weaponType)
    {
        return _currentWeaponInhanceDict[weaponType];
    }

    public void SetWeaponEnhanceLevel(Define.WeaponType weaponType, int level)
    {
        _currentWeaponInhanceDict[weaponType] = level;
        // ������ ����
        Util.SaveJson(_currentWeaponInhanceDict, "CurrentWeaponInhanceData.json");
    }

    public Define.Monster GetMonsterInfo(Define.MonsterType monsterType)
    {
        return _monsterDict[monsterType];
    }
}
