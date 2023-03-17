using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalGold;

    public Define.HeroType heroType;

    public int heroLv;
    public float surviveTime;
    public int killCount;
    public int stageGold;
    public float totalDmg;

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
