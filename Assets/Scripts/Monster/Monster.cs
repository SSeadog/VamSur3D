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

    float _playerSkillDamage;
    float _monsterDamage;

    public float getDamage { get {return _mb.getMonsterStat.power; } } // 영웅에게 데미지를 주는 함수
    public void Init(MonsterBase mb)
    {
        _mb = mb;
    }

    public void hitted()
    {
        if(_mb.getMonsterType == Define.MonsterType.NormalMob)
        {
            _hp = _mb.getMonsterStat.hp;
            _hp -= (int)_playerSkillDamage;
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if(_mb.getMonsterType == Define.MonsterType.ProjectileMob)
        {
            _hp = _mb.getMonsterStat.hp;
            _hp -= (int)_playerSkillDamage;
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if (_mb.getMonsterType == Define.MonsterType.EliteMob)
        {
            _hp = _mb.getMonsterStat.hp;
            _hp -= (int)_playerSkillDamage;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerSkill"))
        {
            _playerSkillDamage = other.GetComponent<SkillProjectile>().Damage;
        }
    }
   

    public void DropGold() // 골드 드롭 
    {

    }
}

public class Gold // 골드 클래스에서 position 계속 업데이트해줌
{ }
