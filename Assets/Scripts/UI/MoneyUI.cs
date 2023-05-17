using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : UIBase
{
    // Todo
    // ���� ������ �޾Ƽ� �����ֱ�
    [SerializeField] int money = 777;

    TMP_Text _text;
    
    void Start()
    {
        _text = transform.Find("Panel/Text").GetComponent<TMP_Text>();
    }

    void Update()
    {
        SetMoney(money);
    }

    void SetMoney(int m)
    {
        _text.text = m.ToString();
    }
}
