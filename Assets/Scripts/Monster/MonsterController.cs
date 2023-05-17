using System.Collections;
using UnityEngine;
using static Define;

public class MonsterController : MonoBehaviour
{
    bool isRespawnCoolTime = false;
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
        if (isRespawnCoolTime == false)
        {
            StartCoroutine(RespawnCollTime());
        }
    }

    IEnumerator RespawnCollTime()
    {
        isRespawnCoolTime = true;
        GenericSingleton<MonsterFactory>.getInstance().SummonMonster();
        Debug.Log("��ȯ");
        yield return new WaitForSeconds(10.0f);
        isRespawnCoolTime = false;
    }
}
  


