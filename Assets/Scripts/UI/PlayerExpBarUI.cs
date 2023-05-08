using UnityEngine;

public class PlayerExpBarUI : UIBase
{
    // Todo
    // 실제 데이터 받아서 연동하기
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
        curExp = GenericSingleton<GameManager>.getInstance().HeroExp - (GenericSingleton<GameManager>.getInstance().HeroLv - 1) * 100f;
        maxExp = 100f;
        ResizeBar(curExp / maxExp);
    }

    void ResizeBar(float percent)
    {
        if (percent < 0)
            percent = 0;

        _foreground.localScale = new Vector3(percent, 1f, 0f);
    }
}
