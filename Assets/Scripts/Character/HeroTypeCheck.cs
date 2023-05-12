using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTypeCheck: MonoBehaviour
{
    Define.Hero _heroData;
    private void Awake()
    {
        HeroCheck(GenericSingleton<GameManager>.getInstance().HeroType);//Managers.Game.heroType== // �κ������ �Ѱ��� �����͸� Ȱ���� �ͼ��õ� Ÿ��
        Debug.Log(_heroData.prefabPath);
        GameObject hero = Resources.Load<GameObject>(_heroData.prefabPath);
        Instantiate(hero);
    }
    void Start()
    {
       
    }
    void HeroCheck(HeroType inheroType)
    {
        Define.HeroType heroType = inheroType;
        Define.Hero heroData = GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        _heroData = heroData;
    }
}
