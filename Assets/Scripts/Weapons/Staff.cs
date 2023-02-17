using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : WeaponBase
{
    GameObject _arrow;
    float _coolTime;
    float _arrowSpeed;
    protected override void InitSkill(Define.Weapon data)
    {
        _coolTime = data.coolTime;
        _arrowSpeed = data.projectileSpeed;
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
            yield return new WaitForSeconds(1f / _coolTime);
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
