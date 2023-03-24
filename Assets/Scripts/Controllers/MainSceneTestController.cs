using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneTestController : MonoBehaviour
{
    WeaponSelectUI _boxInteractionUI;
    GameObject _damageUI;
    GameOverUI _gameOverUI;
    ESCMenuUI _escMenuUI;

    void Start()
    {
        _boxInteractionUI = GameObject.Find("WeaponSelectUI").GetComponent<WeaponSelectUI>();
        
        _damageUI = Resources.Load<GameObject>("Prefabs/UI/DamageUI");
        
        _gameOverUI = GameObject.Find("UIRoot").transform.Find("GameOverUI").GetComponent<GameOverUI>();
        _gameOverUI.Init();

        _escMenuUI = GameObject.Find("UIRoot").transform.Find("ESCMenuUI").GetComponent<ESCMenuUI>();
        _escMenuUI.Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _boxInteractionUI.Open();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _boxInteractionUI.Close();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject instance = Instantiate(_damageUI, transform.position + Vector3.forward, Quaternion.Euler(40, 0, 0));
            instance.GetComponent<DamageUI>().Init(Random.Range(1, 100));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _gameOverUI.ShowUI();
        }
    }
}
