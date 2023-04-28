using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Dictionary<string, UIBase> _dictUI = new Dictionary<string, UIBase>();

    public void AddUI(string key, UIBase uIBase)
    {
        _dictUI.Add(key, uIBase);
    }

    public T GetUI<T>() where T : UIBase
    {
        return _dictUI[typeof(T).ToString()] as T;
    }

    public GameObject GetDamageUI()
    {
        GameObject original = Resources.Load<GameObject>("Prefabs/UI/DamageUI");
        return Instantiate(original);
    }
}
