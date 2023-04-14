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
            // �������� ���� ȹ�� ������ �˸���
            // ������Ʈ�� �ı��Ѵ�
            Destroy(_coinBase);
            Debug.Log("eat");
            
        }
    }
}
