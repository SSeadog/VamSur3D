using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBow : WeaponBase
{
    GameObject _arrow;
    float _attackSpeed;
    protected override void InitSkill()
    {
        _attackSpeed = 2f;
        _arrow = Resources.Load<GameObject>("Prefabs/Weapons/TestBow/TestArrow");
    }

    protected override void StartSkill()
    {
        StartCoroutine(CoFire());
    }

    IEnumerator CoFire()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(1f / _attackSpeed);
        }
    }

    void Fire()
    {
        GameObject instance = Instantiate(_arrow, transform.position + transform.TransformDirection(Vector3.forward) * 2f, transform.rotation);
        instance.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 300f);
        Destroy(instance, 5f);
    }
}
