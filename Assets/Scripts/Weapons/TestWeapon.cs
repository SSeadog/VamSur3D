using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestWeapon : WeaponBase
{
    GameObject _attackJudge;
    float _attackSpeed;
    float _rebound;
    float _detectTime;

    protected override void InitSkill()
    {
        _attackSpeed = 2f;
        _rebound = 1f;
        _detectTime = 0.1f;
        _attackJudge = Resources.Load<GameObject>("Prefabs/Weapons/TestWeapon/AttackJudge");
    }

    protected override void StartSkill()
    {
        StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        while (true)
        {
            Skill();

            yield return new WaitForSeconds(1f / _attackSpeed);
        }
    }

    void Skill()
    {
        GameObject skillJudgeInstance = Instantiate(_attackJudge);

        // transform.rotaion으로 벡터 구해보기
        float rad = GetMouseDirAngle();
        float tempRad = Random.Range(rad - _rebound, rad + _rebound);
        Vector3 vec = new Vector3(Mathf.Sin(tempRad), 0f, Mathf.Cos(tempRad));

        skillJudgeInstance.transform.position = transform.position + vec * 1.5f;
        skillJudgeInstance.transform.rotation = Quaternion.AngleAxis(tempRad * Mathf.Rad2Deg, Vector3.up);

        Destroy(skillJudgeInstance, _detectTime);
    }
}
