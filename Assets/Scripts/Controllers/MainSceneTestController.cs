using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneTestController : MonoBehaviour
{
    BoxInteractionUI _boxInteractionUI;
    GameObject _damageUI;
    GameOverUI _gameOverUI;

    void Start()
    {
        _boxInteractionUI = GameObject.Find("BoxInteractionUI").GetComponent<BoxInteractionUI>();
        _damageUI = Resources.Load<GameObject>("Prefabs/UI/DamageUI");
        _gameOverUI = GameObject.Find("UIRoot").transform.Find("GameOverUI").GetComponent<GameOverUI>();
        _gameOverUI.Init();
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
