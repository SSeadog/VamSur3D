using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneTestController : MonoBehaviour
{
    BoxInteractionUI _boxInteractionUI;
    GameObject _damageUI;

    void Start()
    {
        _boxInteractionUI = GameObject.Find("BoxInteractionUI").GetComponent<BoxInteractionUI>();
        _damageUI = Resources.Load<GameObject>("Prefabs/UI/DamageUI");
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
    }
}
