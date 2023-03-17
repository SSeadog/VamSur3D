using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterController _mc;
    Transform _hero;
    Define.Monster _normalMonsterInfo;
    Define.Monster _projectileMonsterInfo;
    Define.Monster _eliteMonsterInfo;


    public Define.MonsterType type;
    int _hp;

    public void LoadData()
    {
        _normalMonsterInfo = Managers.Data.GetMonsterInfo(Define.MonsterType.NormalMob);
        _projectileMonsterInfo = Managers.Data.GetMonsterInfo(Define.MonsterType.ProjectileMob);
        _eliteMonsterInfo = Managers.Data.GetMonsterInfo(Define.MonsterType.EliteMob);
    }
    private void Start()
    {
        LoadData();
    }

  
    private void Update()
    {
        
    }

    public void init(MonsterController mc, Transform hero)
    {
       
        _mc = mc;
        _hero = hero;
        _hp = _normalMonsterInfo.hp; 
        
        


    }
}
