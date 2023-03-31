using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected float _power;
    protected float _coolTime;
    protected int _projectileCount;
    protected float _projectileSpeed;
    protected int _enhenceLevel;

    public virtual void Init(Define.Weapon data)
    {
        InitSkill(data);
        StartSkill();
    }

    protected virtual void InitSkill(Define.Weapon data)
    {
        Define.WeaponType type = (Define.WeaponType)data.id;
        _power = data.power;
        _coolTime = data.coolTime;
        _projectileCount = data.projectileCount;
        _projectileSpeed = data.projectileSpeed;
        _enhenceLevel = Managers.Data.GetWeaponEnhenceLevel(type);

    }

    protected abstract void StartSkill();

    protected float GetMouseDirAngle()
    {
        Vector3 mousePos = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
            mousePos = hitInfo.point;

        Vector3 dir = (mousePos - transform.position).normalized;
        float rad = Mathf.Atan2(dir.x, dir.z);

        return rad;
    }

    private void ApplyEnhenceLevel(Define.Weapon data)
    {
    }

    public float GetPower()
    {
        return _power * (1f + 0.05f * _enhenceLevel);
    }

    public abstract void Clear();
}
