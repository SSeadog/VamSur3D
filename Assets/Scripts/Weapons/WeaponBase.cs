using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public virtual void Init()
    {
        InitSkill();
        StartSkill();
    }

    protected abstract void InitSkill();

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
}
