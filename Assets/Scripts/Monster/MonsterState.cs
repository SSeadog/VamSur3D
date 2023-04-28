using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace State{
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
                //if (_mb.getMonsterType == Define.MonsterType.NormalMob)
                //{
                //    _hp -= (int)_playerSkillDamage;
                //    if (_hp <= 0)
                //    {
                //        Die();
                //    }
                //}
                //else if (_mb.getMonsterType == Define.MonsterType.ProjectileMob)
                //{
                //    _hp -= (int)_playerSkillDamage;
                //    if (_hp <= 0)
                //    {
                //        Die();
                //    }
                //}
                //else if (_mb.getMonsterType == Define.MonsterType.EliteMob)
                //{
                //    _hp -= (int)_playerSkillDamage;
                //    if (_hp <= 0)
                //    {
                //        Die();
                //    }
                //}
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
            base.MainLoop();
        }

        public void Die()
        {
            //isDie = true;
            //gameObject.SetActive(false);
            //GameObject tmp = Instantiate(_coin);
            //tmp.transform.position = transform.position;
        }
    }
}
