using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace State
{
    public class MonsterState
    {
        protected Monster _monster;

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

    }

    public class HittedState : MonsterState
    {
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }

        public override void MainLoop()
        {
            void hitted()
            {
                if (_monster.sendMonsterType == Define.MonsterType.NormalMob)
                {
                    _monster._hp -= (int)_monster.sendSkillDamage;
                    if (_monster._hp <= 0)
                    {
                        _monster.ChangeUnitState(new DieState());
                    }
                }
                else if (_monster.sendMonsterType == Define.MonsterType.ProjectileMob)
                {
                    _monster._hp -= (int)_monster.sendSkillDamage;
                    if (_monster._hp <= 0)
                    {
                        _monster.ChangeUnitState(new DieState());
                    }
                }
                else if (_monster.sendMonsterType == Define.MonsterType.EliteMob)
                {
                    _monster._hp -= (int)_monster.sendSkillDamage;
                    if (_monster._hp <= 0)
                    {
                        _monster.ChangeUnitState(new DieState());
                    }
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
            void Die()
            {
                isDie = true;
                _monster.gameObject.SetActive(false);
                //GameObject tmp = Instantiate(_monster.sendGemInfo);
                //tmp.transform.position = _monster.transform.position;
            }
        }
    }
}
