using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public UIManager uIManager;
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
            uIManager.playerStatusUI.SetLv(heroLv);
            // 무기 선택 UI 띄우기
            uIManager.weaponSelectUI.Open();
        }
    }

    public void Init()
    {
        // 임시 데이터
        totalGold = 9999;
        
        heroType = Define.HeroType.Wizard;

        heroLv = 29;
        surviveTime = 1800f;
        killCount = 999;
        stageGold = 299;
        totalDmg = 19999f;
    }

    public void Clear()
    {

    }
}