using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalGold;

    public GameObject player;
    public Define.HeroType heroType;
    public Dictionary<Define.WeaponType, int> playerWeaponLevels;
    public int heroLv = 1;
    public int heroExp;
    public float surviveTime;
    public int killCount;
    public int stageGold;
    public float totalDmg;

    public void GetExp(int exp)
    {
        heroExp += exp;
        if (heroExp >= heroLv * 100) // 레벨업 조건은 임시 조건. 추후 수정 필요
        {
            heroLv++;
            GenericSingleton<UIManager>.getInstance().GetUI<PlayerStatusUI>().SetLv(heroLv);
            // 무기 선택 UI 띄우기
            GenericSingleton<UIManager>.getInstance().GetUI<WeaponSelectUI>().Open();
        }
    }

    public void Clear()
    {
        player = null;
        heroType = Define.HeroType.None;
        playerWeaponLevels.Clear();
        heroLv = 0;
        heroExp = 0;
        surviveTime = 0f;
        killCount = 0;
        stageGold = 0;
        totalDmg = 0f;
    }
}