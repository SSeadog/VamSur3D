using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBarUI : MonoBehaviour
{
    // Todo
    // ���� Player HP ������ �޾Ƽ� ���������� UI���ŵǵ��� �ؾ���
    float maxHP = 100f;
    [SerializeField] float curHP = 70f;

    GameObject _target;
    Vector3 _offset;

    RectTransform _foreground;

    public void Init()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _offset = new Vector3(0, -0.5f, -1f);

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
