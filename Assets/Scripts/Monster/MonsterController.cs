using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : MonoBehaviour
{
    [SerializeField] GameObject _coin;
    //���� ��ȭ ųī��Ʈ
    //����Ʈ ���� ��ȯ�Ǵ� ųī��Ʈ 200����
    //���� �ѷ� ųī��Ʈ, ����Ʈ���ʹ� �ѷ� �ϳ��� �� ��,
    // >> ųī��Ʈ 100���� 100 �ѷ� 200�����ϋ� ��ȭ
    //�ӽ� 5�� �þ �Ϲݸ�, ����ü
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenericSingleton<MonsterFactory>.getInstance().SummonMonster();
        }

    }

    public GameObject DropCoin { get { return _coin; } }
}
  


