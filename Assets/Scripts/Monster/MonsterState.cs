using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }
        public override void MainLoop()
        {
            
            //플레이어를 따라가도록 하는 기능
        }
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
