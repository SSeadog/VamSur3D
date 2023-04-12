using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterBase _mb;

    int _hp;

    bool isDie = false;



    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void hitted(MonsterBase mb)
    {
        _mb = mb;
        if(_mb.getMonsterType() == Define.MonsterType.NormalMob)
        {
            _hp = Managers.Data.GetMonsterInfo(Define.MonsterType.NormalMob).hp;
            _hp -= (int)getDamage();
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if(_mb.getMonsterType() == Define.MonsterType.ProjectileMob)
        {
            _hp = Managers.Data.GetMonsterInfo(Define.MonsterType.ProjectileMob).hp;
            _hp -= (int)getDamage();
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if (_mb.getMonsterType() == Define.MonsterType.EliteMob)
        {
            _hp = Managers.Data.GetMonsterInfo(Define.MonsterType.EliteMob).hp;
            _hp -= (int)getDamage();
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

    public float getDamage() // 영웅 데미지 데이터 가져와서 리턴
    {
        float damage = 10;
        return damage;
    }

    public void DropGold() // 골드 드롭 
    {

    }
}

public class Gold // 골드 클래스에서 position 계속 업데이트해줌
{ }
