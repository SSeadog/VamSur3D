using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterBase : MonoBehaviour
{
    protected GameObject _obj;
    protected Define.Monster _monStat;
    protected Define.MonsterType _monType;

    public Define.MonsterType getMonsterType()
    {
        return _monType;
    }


    public abstract void Init();

}

public class NormolMonster : MonsterBase
{
    public override void Init()
    {
        _monStat = Managers.Data.GetMonsterInfo(Define.MonsterType.NormalMob);
        _monType = Define.MonsterType.NormalMob;
        _obj = GenericSingleton<MonsterPool>.getInstance().GetPoolObject(Define.MonsterType.NormalMob);
        _obj.transform.position =  new Vector3(Random.Range(-20f, 20), 0.5f, Random.Range(-20f, 20f));
    }
}

public class ProjectileMonster : MonsterBase
{
    public override void Init()
    {
        _monStat = Managers.Data.GetMonsterInfo(Define.MonsterType.ProjectileMob);
        _monType = Define.MonsterType.ProjectileMob;
        _obj = GenericSingleton<MonsterPool>.getInstance().GetPoolObject(Define.MonsterType.ProjectileMob);
        _obj.transform.position =  new Vector3(Random.Range(-20f, 20), 0.5f, Random.Range(-20f, 20f));
    }
}

public class EliteMonster : MonsterBase
{
    public override void Init()
    {
        _monStat = Managers.Data.GetMonsterInfo(Define.MonsterType.EliteMob);
        _monType = Define.MonsterType.EliteMob;
        _obj = GenericSingleton<MonsterPool>.getInstance().GetPoolObject(Define.MonsterType.EliteMob);
        _obj.transform.position =  new Vector3(Random.Range(-20f, 20), 0.75f, Random.Range(-20f, 20f));
    }
}

public class GenericSingleton<T> where T : MonoBehaviour
{
    private static T _instance;
    public static T getInstance()
    {
        if (_instance == null)
        {
            GameObject temp = new GameObject();
            _instance = temp.AddComponent<T>();
            Object.DontDestroyOnLoad(temp);
        }
        return _instance;
    }
}

