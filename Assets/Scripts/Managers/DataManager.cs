using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager _instance;
    public static DataManager Instance { get { Init(); return _instance; } }

    //public GameManager _game = new GameManager();
    //public GameManager Game { get { return _instance._game; } }

    private Dictionary<Define.WeaponType, Dictionary<int, Define.Weapon>> weaponDict;
    private Dictionary<Define.WeaponType, int> currentWeaponInhenceDict;

    public static void Init()
    {
        if (_instance == null)
        {
            // _instance를 채우기 위한 로직
            GameObject go = GameObject.Find("DataManager");
            if (go == null)
            {
                go = new GameObject("DataManager");
            }

            DataManager mg = go.GetComponent<DataManager>();
            if (mg == null)
            {
                mg = go.AddComponent<DataManager>();
            }

            DontDestroyOnLoad(mg);

            _instance = mg;

            // 무기 정보 로드
            _instance.weaponDict = Util.LoadJsonDict<Define.WeaponType, Dictionary<int, Define.Weapon>>("Data/WeaponData");
            _instance.currentWeaponInhenceDict = Util.LoadJsonDict<Define.WeaponType, int>("Data/CurrentWeaponInhenceData");
        }
    }

    void Start()
    {
        Init();
        Util.WriteJson("", _instance.currentWeaponInhenceDict);
    }

    public Define.Weapon GetWeaponInfo(Define.WeaponType weaponType, int level)
    {
        return _instance.weaponDict[weaponType][level];
    }

    public int GetWeaponEnhenceLevel(Define.WeaponType weaponType)
    {
        return _instance.currentWeaponInhenceDict[weaponType];
    }
}
