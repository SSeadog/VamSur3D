using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterBase _mb;
    WeaponBase _wb;
    HeroMove _hero;

    public Define.MonsterType _monType;
    public Define.Monster _monStat;

    float _hp;

    bool isDie = false;

    private void Start()
    {
        
    }

    public void LoadMonsterData(MonsterBase mb)
    {
        _monType = mb.getMonsterType();
        _monStat = mb.getMonsterStat();
    }



    public void hitted()
    {
        if(_monType == Define.MonsterType.NormalMob)
        {
            _hp = _monStat.hp;
            _hp -= getDamage(_wb);
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if(_mb.getMonsterType() == Define.MonsterType.ProjectileMob)
        {
            _hp = _monStat.hp;
            _hp -= getDamage(_wb);
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if (_mb.getMonsterType() == Define.MonsterType.EliteMob)
        {
            _hp = _monStat.hp;
            _hp -= getDamage(_wb);
            if (_hp <= 0)
            {
                Die();
            }
        }

    }

    public void Die()
    {
        isDie = true;
        gameObject.SetActive(false);
    }

    public float getDamage(WeaponBase wb) // 영웅 데미지 데이터 가져와서 리턴
    {
        _wb = wb;
        float damage = _wb.GetPower();
        return damage;
    }


    public void DropGold() // 골드 드롭 
    {

    }
}

public class Gold // 골드 클래스에서 position 계속 업데이트해줌
{ }
