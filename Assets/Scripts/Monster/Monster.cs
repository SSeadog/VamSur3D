using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] GameObject _coin;
    MonsterBase _mb;
    

    public int _hp;

    bool isDie = false;

    float _playerSkillDamage;
    float _monsterDamage;

    public float getDamage { get {return _mb.getMonsterStat.power; } } // 영웅에게 데미지를 주는 함수
    public void Init(MonsterBase mb)
    {
        _mb = mb;
        _hp = _mb.getMonsterStat.hp;
    }

    public Define.MonsterType sendMonsterType { get { return _mb.getMonsterType; } }

    public void hitted()
    {
        if(_mb.getMonsterType == Define.MonsterType.NormalMob)
        {
            _hp -= (int)_playerSkillDamage;
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if(_mb.getMonsterType == Define.MonsterType.ProjectileMob)
        {
            _hp -= (int)_playerSkillDamage;
            if (_hp <= 0)
            {
                Die();
            }
        }
        else if (_mb.getMonsterType == Define.MonsterType.EliteMob)
        {
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
        GameObject tmp = Instantiate(_coin);
        tmp.transform.position = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerSkill"))
        {
            _playerSkillDamage = other.gameObject.GetComponent<SkillProjectile>().Damage;
            hitted();
            Debug.Log("hit");
        }
    }
}

public class Gold // 골드 클래스에서 position 계속 업데이트해줌
{ }
