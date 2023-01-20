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
}
