using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBarUI : MonoBehaviour
{
    // Todo
    // 실제 Player HP 데이터 받아서 지속적으로 UI갱신되도록 해야함
    float maxHP = 100f;
    [SerializeField] float curHP = 70f;

    GameObject _target;
    Vector3 _offset;

    RectTransform _foreground;

    public void Init()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _offset = new Vector3(0, 0.2f, -1f);

        transform.rotation = Camera.main.transform.rotation;

        _foreground = transform.Find("Panel/Foreground").GetComponent<RectTransform>();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        transform.position = _target.transform.position + _offset;
        ResizeBar(curHP / maxHP);
    }

    void ResizeBar(float percent)
    {
        _foreground.localScale = new Vector3(percent, 1f, 0f);
    }
}
