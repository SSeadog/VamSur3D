using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject _coinBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 영웅에게 코인 획득 정보를 알린다
            // 오브젝트를 파괴한다
            Destroy(_coinBase);
            Debug.Log("eat");
            
        }
    }
}
