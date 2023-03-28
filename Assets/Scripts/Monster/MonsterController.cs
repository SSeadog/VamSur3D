using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] Transform monsterParent;
    [SerializeField] GameObject _hero;
    GameObject _Nmonster;
    GameObject _Pmonster;
    GameObject _Emonster;

    Transform _heroPosition;
    List<Monster> mons = new List<Monster>();

    int normalMonsterCount = 0;
    int projectileMonsterCount = 0;
    int _killCountStep;
    int _heroKillCount;

    //몬스터 강화 킬카운트
    //엘리트 몬스터 소환되는 킬카운트 200단위
    //몬스터 총량 킬카운트, 엘리트몬스터는 총량 하나로 고 정,
    // >> 킬카운트 100단위 100 총량 200단위일떈 강화
    //임시 5씩 늘어남 일반몹, 투사체

    private void Start()
    {
        
        _Nmonster = Resources.Load("Prefabs/Monster/NormalMob") as GameObject;
        _Pmonster = Resources.Load("Prefabs/Monster/ProjectileMob") as GameObject;
        _Emonster = Resources.Load("Prefabs/Monster/EliteMob") as GameObject;
        _heroPosition = _hero.GetComponent<Transform>();
        makeMonsters();
    }
    public void makeMonsters()
    {
        for(int i=0; i< 20; i++)
        { 
            GameObject Nmon = Instantiate(_Nmonster, monsterParent);
            Nmon.name = "NormalMob";
            Nmon.AddComponent<Monster>();
            Nmon.GetComponent<Monster>().type = Define.MonsterType.NormalMob;
            mons.Add(Nmon.GetComponent<Monster>());
            normalMonsterCount++;
        }
        for(int i=0; i<4; i++)
        {
            GameObject Pmon = Instantiate(_Pmonster, monsterParent);
            Pmon.name = "ProjectileMob";
            Pmon.AddComponent<Monster>();
            Pmon.GetComponent<Monster>().type = Define.MonsterType.ProjectileMob;
            mons.Add(Pmon.GetComponent<Monster>());
            projectileMonsterCount++;
        }

        GameObject Emon = Instantiate(_Emonster, monsterParent);
        Emon.name = "EliteMob";
        Emon.AddComponent<Monster>();
        Emon.GetComponent<Monster>().type = Define.MonsterType.EliteMob;
        mons.Add(Emon.GetComponent<Monster>());

        foreach(Monster mon in mons)
        {
            if(mon.GetComponent<Monster>().type == Define.MonsterType.NormalMob)
            {
                mon.NorMobinit(this, _heroPosition);
            }
            else if (mon.GetComponent<Monster>().type == Define.MonsterType.ProjectileMob)
            {
                mon.ProMobinit(this, _heroPosition);
            }
            else if(mon.GetComponent<Monster>().type == Define.MonsterType.EliteMob)
            {
                mon.EliMobinit(this, _heroPosition);
            }
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
                    _mon.NorMobinit(this, _heroPosition);
                    normalMonsterCount++;
                }
                else if (_mon.GetComponent<Monster>().type == Define.MonsterType.ProjectileMob)
                {
                    _mon.ProMobinit(this, _heroPosition);
                    projectileMonsterCount++;
                }
                else if (_mon.GetComponent<Monster>().type == Define.MonsterType.EliteMob)
                {
                    _mon.EliMobinit(this, _heroPosition);
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
=======
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenericSingleton<MonsterFactory>.getInstance().SummonMonster();
        }
>>>>>>> parent of 7c5c1d0 (Revert "Revert "Revert "紐ъ뒪�꽣 �삤釉뚯젥�듃���留�, �뙥�넗由� �뙣�꽩 �쟻�슜�빐遊�""")
    }
}
  


