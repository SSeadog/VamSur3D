using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager _instance;
    public static MainGameManager Instance { get { return _instance; } }

    public Dictionary<string,Dictionary<int, Define.Weapon>> weaponDict;

    static void Init()
    {
        if (_instance != null)
            return;

        GameObject go = GameObject.Find("MainGameManager");
        if (go == null)
        {
            go = new GameObject("MainGameManager");
        }

        MainGameManager mg = go.GetComponent<MainGameManager>();
        if (mg == null)
        {
            mg = go.AddComponent<MainGameManager>();
        }

        _instance = mg;

        _instance.weaponDict = Util.LoadJsonDict<Dictionary<int, Define.Weapon>>("Data/WeaponData");
    }

    void Start()
    {
        Init();
    }

}
