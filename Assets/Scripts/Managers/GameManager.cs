using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Dictionary<Define.WeaponType, int> _playerWeaponLevels = new Dictionary<Define.WeaponType, int>();

    public GameObject Player { get; set; }
    public Define.HeroType HeroType { get; set; } = Define.HeroType.Wizard;
    public int HeroLv { get; set; }
    public int HeroExp { get; set; }
    public float SurviveTime { get; set; }
    public int KillCount { get; set; }
    public int TotlGold { get; set; }
    public int StageGold { get; set; }
    public float TotalDmg { get; set; }

    public void GetExp(int exp)
    {
        HeroExp += exp;
        if (HeroExp >= HeroExp * 100) // ������ ������ �ӽ� ����. ���� ���� �ʿ�
        {
            HeroLv++;
            GenericSingleton<UIManager>.getInstance().GetUI<PlayerStatusUI>().SetLv(HeroLv);
            // ���� ���� UI ����
            GenericSingleton<UIManager>.getInstance().GetUI<WeaponSelectUI>().Open();
        }
    }

    public List<Define.WeaponType> GetCurrentWeaponList()
    {
        return new List<Define.WeaponType>(_playerWeaponLevels.Keys);
    }

    public int GetCurrentWeaponLevel(Define.WeaponType type)
    {
        return _playerWeaponLevels[type];
    }

    public void SetPlayerWeaponLevel(Define.WeaponType type, int level)
    {
        if (_playerWeaponLevels.ContainsKey(type))
        {
            _playerWeaponLevels[type] = level;
        }
        else
        {
            _playerWeaponLevels.Add(type, level);
        }
    }

    public void Clear()
    {
        Player = null;
        HeroType = Define.HeroType.None;
        _playerWeaponLevels.Clear();
        HeroLv = 0;
        HeroExp = 0;
        SurviveTime = 0f;
        KillCount = 0;
        StageGold = 0;
        TotalDmg = 0f;
    }
}