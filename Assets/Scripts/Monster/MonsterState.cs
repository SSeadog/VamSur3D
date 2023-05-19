using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace State
{
    public class MonsterState
    {
        protected Monster _monster;

        bool _isHit;
        

        public virtual void OnEnter(Monster monster)
        {
            _monster = monster;
        }

        public virtual void MainLoop()
        {

        }
    }

    public class MoveState : MonsterState
    {
        Hero _hero;
        int monsterSpeed = 2;
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }
        public override void MainLoop()
        {
            _hero = GenericSingleton<GameManager>.getInstance().Player.gameObject.GetComponent<Hero>();
            //플레이어를 따라가도록 하는 기능
            _monster.transform.position = Vector3.MoveTowards(_monster.transform.position, _hero.transform.position, Time.deltaTime * monsterSpeed);


        }

        

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if(collision.gameObject.CompareTag("Player"))
        //    {
        //        _hero = collision.gameObject.GetComponent<Hero>();
        //    }

        //}
    }

    public class HittedState : MonsterState
    {
        int _hp;
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }

        public override void MainLoop()
        {

           
            _hp = _monster._hp;
            if (_monster.sendMonsterType == Define.MonsterType.NormalMob)
            {
                _hp -= (int)_monster.sendSkillDamage;
                if (_hp <= 0)
                {
                    _monster.ChangeUnitState(new DieState());
                }
                else
                {
                    _monster.ChangeUnitState(new MoveState());
                }
            }
            else if (_monster.sendMonsterType == Define.MonsterType.ProjectileMob)
            {
                _hp -= (int)_monster.sendSkillDamage;
                if(_hp <= 0)
                {
                    _monster.ChangeUnitState(new DieState());
                }
                else
                {
                    _monster.ChangeUnitState(new MoveState());
                }
            }
            else if (_monster.sendMonsterType == Define.MonsterType.EliteMob)
            {
                _hp -= (int)_monster.sendSkillDamage;
                if (_hp <= 0)
                {
                    _monster.ChangeUnitState(new DieState());
                }
                else
                {
                    _monster.ChangeUnitState(new MoveState());
                }

            }
        }

     

    }

    public class DieState : MonsterState
    {
        bool isDie = false;
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }

        public override void MainLoop()
        {
            isDie = true;
            _monster.gameObject.SetActive(false);
            GameObject tmp = GameObject.Instantiate(_monster.sendGemInfo);
            tmp.transform.position = _monster.transform.position;
        }
    }
}
