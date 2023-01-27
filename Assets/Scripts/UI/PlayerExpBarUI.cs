using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpBarUI : MonoBehaviour
{
    // Todo
    // ���� ������ �޾Ƽ� �����ϱ�
    float maxExp = 10000f;
    [SerializeField] float curExp = 7500f;

    RectTransform _foreground;

    public void Init()
    {
        _foreground = transform.Find("Panel/Foreground").GetComponent<RectTransform>();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        ResizeBar(curExp / maxExp);
    }

    void ResizeBar(float percent)
    {
        _foreground.localScale = new Vector3(percent, 1f, 0f);
    }
}
