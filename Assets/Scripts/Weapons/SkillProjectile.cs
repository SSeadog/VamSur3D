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

        Debug.Log($"{gameObject.name}��ų �浹!! ��� : {other.name}");
        //if (other.CompareTag("Monster"))
        //{
        //    // ���� ���� �����ͼ� ������ ����
        //}
    }
}
