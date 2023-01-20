using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestWeapon : WeaponBase
{
    GameObject _attackJudge;
    float _attackSpeed;

    protected override void InitSkill()
    {
        _attackSpeed = 2f;
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
        float y = transform.eulerAngles.y * Mathf.Deg2Rad;
        Vector3 vec = new Vector3(Mathf.Sin(y), 0, Mathf.Cos(y));

        //skillJudgeInstance.transform.position = transform.position + transform.TransformDirection(Vector3.forward) * 3f;
        skillJudgeInstance.transform.position = transform.position + vec * 3f;
        skillJudgeInstance.transform.rotation = transform.rotation;

        Destroy(skillJudgeInstance, 0.1f);
    }
}
