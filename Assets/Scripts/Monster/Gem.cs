using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] GameObject _gemBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �������� ����ġ�� �ش�


            // ������Ʈ�� �ı��Ѵ�
            Destroy(_gemBase);
            Debug.Log("eat");
            
        }
    }

    private void Update()
    {
        //������ �����Ÿ� �������� ������̵����ϴ� ���� �߰�
        //õõ�� ���������� ���
        //��ġ�� ������ ���������
        transform.position = Vector3.Lerp(transform.position, GenericSingleton<GameManager>.getInstance().player.transform.position, 0.5f);
    }
}
