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
        // tag로 몬스터인지 확인해서 몬스터일 때만 데미지 주기
        if (!other.CompareTag("Monster"))
            return;

        // 데미지는 _damage를 이용해서 전달
        Debug.Log($"{gameObject.name}스킬 충돌!! 대상 : {other.name} 데미지 : {_damage}");
    }
}
