using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers _instance;
    public static Managers Instance { get { Init(); return _instance; } }

    public DataManager _data = new DataManager();
    public GameManager _game = new GameManager();
    

    public static DataManager Data { get { return Instance._data; } }
    public static GameManager Game { get { return Instance._game; } }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject("@Managers");
                go.AddComponent<Managers>();
            }

            Managers mg = go.GetComponent<Managers>();
            if (mg == null)
            {
                mg = go.AddComponent<Managers>();
            }

            _instance = mg;
            DontDestroyOnLoad(_instance);

            _instance._data.Init();
        }
    }

    void Start()
    {
        Init();
    }

    public void Clear()
    {

    }

}
