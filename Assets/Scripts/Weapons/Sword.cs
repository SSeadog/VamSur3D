using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Sword : WeaponBase
{
    GameObject _attackJudge;
    float _coolTime;
    float _rebound;
    float _detectTime;

    protected override void InitSkill(Define.Weapon data)
    {
        _coolTime = data.coolTime;
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

            yield return new WaitForSeconds(_coolTime);
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
