using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    // Todo
    // ũ��Ƽ�� ������ �� ���� �ʿ�
    // ���� �ִϸ��̼��� Ŀ���ٰ� �۾����� �ɷ� ���� �ʿ�
    float _lifeTime = 0.5f;
    float _timer = 0;

    Vector3 _moveVec = new Vector3(0, 1f, 0);
    float _speed = 3f;

    TMP_Text _damageText;
    public void Init(int damage)
    {
        _damageText = gameObject.GetComponentInChildren<TMP_Text>();
        _damageText.text = damage.ToString();
    }

    void Update()
    {
        Vector3 endVec = transform.position + _moveVec;
        transform.position = Vector3.Lerp(transform.position, endVec, Time.deltaTime * _speed);

        _timer += Time.deltaTime;
        if (_timer > _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
