using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBow : WeaponBase
{
    GameObject _arrow;
    float _attackSpeed;
    float _arrowSpeed;
    protected override void InitSkill()
    {
        _attackSpeed = 10f;
        _arrowSpeed = 300f;
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
        float rad = GetMouseDirAngle();
        // 해당 각도로 발사
        Vector3 moveVec = new Vector3(Mathf.Sin(rad), 0f, Mathf.Cos(rad));

        GameObject instance = Instantiate(_arrow, transform.position + moveVec, Quaternion.AngleAxis(rad * Mathf.Rad2Deg, Vector3.up));
        instance.GetComponent<Rigidbody>().AddForce(moveVec * _arrowSpeed);
        Destroy(instance, 5f);
    }
}
