using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : UIBase
{
    // Todo
    // 실제 데이터 받아서 보여주기
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
