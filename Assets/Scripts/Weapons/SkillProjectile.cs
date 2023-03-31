using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProjectile : MonoBehaviour
{
    float _damage = 0f;

    public void Init(float damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerSkill"))
            return;

        Debug.Log($"{gameObject.name}스킬 충돌!! 대상 : {other.name}");
        //if (other.CompareTag("Monster"))
        //{
        //    // 몬스터 스탯 가져와서 데미지 전달
        //}
    }
}
