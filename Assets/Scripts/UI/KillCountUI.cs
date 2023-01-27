using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCountUI : MonoBehaviour
{
    // Todo
    // 실제 데이터 받아서 보여주기
    [SerializeField] int killCount = 1234;

    TMP_Text _text;

    void Start()
    {
        _text = transform.Find("Panel/Text").GetComponent<TMP_Text>();
    }

    void Update()
    {
        SetKillCount(killCount);
    }

    void SetKillCount(int kc)
    {
        _text.text = kc.ToString();
    }
}
