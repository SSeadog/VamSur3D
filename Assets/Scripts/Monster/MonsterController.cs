using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : MonoBehaviour
{
    [SerializeField] Transform monsterParent;
    [SerializeField] GameObject _hero;
    [SerializeField] GameObject _Nmonster;
    [SerializeField] GameObject _Pmonster;
    [SerializeField] GameObject _Emonster;

    Transform _heroPosition;
    List<Monster> mons = new List<Monster>();

    int normalMonsterCount = 0;
    int projectileMonsterCount = 0;
    int _killCountStep;
    int _heroKillCount;

    //몬스터 강화 킬카운트
    //엘리트 몬스터 소환되는 킬카운트 200단위
    //몬스터 총량 킬카운트, 엘리트몬스터는 총량 하나로 고정,
    // >> 킬카운트 100단위 100 총량 200단위일떈 강화
    //임시 5씩 늘어남 일반몹, 투사체

    private void Start()
    {
        _heroPosition = _hero.GetComponent<Transform>();
        makeMonsters();
    }
    public void makeMonsters()
    {
        for(int i=0; i< 20; i++)
        { 
            GameObject Nmon = Instantiate(_Nmonster, monsterParent);
            Nmon.name = "NormalMob";
            Nmon.GetComponent<Monster>().type = Define.MonsterType.NormalMob;
            mons.Add(Nmon.GetComponent<Monster>());
            normalMonsterCount++;
        }
        for(int i=0; i<4; i++)
        {
            GameObject Pmon = Instantiate(_Pmonster, monsterParent);
            Pmon.name = "ProjectileMob";
            Pmon.GetComponent<Monster>().type = Define.MonsterType.ProjectileMob;
            mons.Add(Pmon.GetComponent<Monster>());
            projectileMonsterCount++;
        }

        GameObject Emon = Instantiate(_Emonster, monsterParent);
        Emon.name = "EliteMob";
        Emon.GetComponent<Monster>().type = Define.MonsterType.EliteMob;
        mons.Add(Emon.GetComponent<Monster>());

        foreach(Monster mon in mons)
        {
            mon.init(this, _heroPosition);
        }
        
    }

    public void newMakeMonster()
    {
        bool isNew = true;
        foreach (Monster _mon in mons)
        {
            if (_mon.gameObject.activeSelf == false)
            {
                if (_mon.GetComponent<Monster>().type == Define.MonsterType.NormalMob)
                {
                    _mon.init(this, _heroPosition);
                    normalMonsterCount++;
                }
                else if (_mon.GetComponent<Monster>().type == Define.MonsterType.ProjectileMob)
                {
                    _mon.init(this, _heroPosition);
                    projectileMonsterCount++;
                }
                else
                {
                    _mon.init(this, _heroPosition);
                }
                isNew = false;
                break;
            }

        }
        //    if (isNew)
        //    {
        //        GameObject mon = Instantiate(_monster);
        //        mon.GetComponent<Monster>().init(this, _hero);
        //        mons.Add(mon.GetComponent<Monster>());
        //    }
        //}

        //int GetKillCountStep()
        //{
        //    if()

        //    return
        //}
    }
}
