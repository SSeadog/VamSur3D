using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterController _mc;
    Transform _hero;
    Define.Monster _normalMonsterInfo;
    Define.Monster _projectileMonsterInfo;
    Define.Monster _eliteMonsterInfo;


    public Define.MonsterType type;
    int _id;
    float _hp;
    float _power;
    int _exp;
    int _projectileCount;


    public void LoadData()
    {
        _normalMonsterInfo = Managers.Data.GetMonsterInfo(Define.MonsterType.NormalMob);
        _projectileMonsterInfo = Managers.Data.GetMonsterInfo(Define.MonsterType.ProjectileMob);
        _eliteMonsterInfo = Managers.Data.GetMonsterInfo(Define.MonsterType.EliteMob);
    }
    private void Awake()
    {
        LoadData();
    }

  
    private void Update()
    {
        
    }

    public void NorMobinit(MonsterController mc, Transform hero)
    {
        _mc = mc;
        _hero = hero;
        _id = _normalMonsterInfo.id;
        _hp = _normalMonsterInfo.hp;
        _power = _normalMonsterInfo.power;
        _exp = _normalMonsterInfo.exp;
        gameObject.SetActive(true);
        Vector3 ranPos = _hero.position + new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
        transform.position = ranPos;
        
    }

    public void ProMobinit(MonsterController mc, Transform hero)
    {
        _mc = mc;
        _hero = hero;
        _id = _projectileMonsterInfo.id;
        _hp = _projectileMonsterInfo.hp;
        _power = _projectileMonsterInfo.power;
        _projectileCount = _projectileMonsterInfo.projectileCount;
        _exp = _projectileMonsterInfo.exp;
        gameObject.SetActive(true);
        Vector3 ranPos = _hero.position + new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
        transform.position = ranPos;

    }

    public void EliMobinit(MonsterController mc, Transform hero)
    {
        _mc = mc;
        _hero = hero;
        _id = _eliteMonsterInfo.id;
        _hp = _eliteMonsterInfo.hp;
        _power = _eliteMonsterInfo.power;
        _exp = _eliteMonsterInfo.exp;
        gameObject.SetActive(true);
        Vector3 ranPos = _hero.position + new Vector3(Random.Range(-10f, 10f), 0.75f, Random.Range(-10f, 10f));
        transform.position = ranPos;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void hitted()
    {
        _hp -= getDamage();
        if(_hp <= 0)
        {
            hitted();
        }
    }

    public float getDamage()
    {
        float damage = 10;
        return damage;
    }
}
