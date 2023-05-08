using UnityEngine;
using UnityEngine.UI;

public class CaracterData : MonoBehaviour
{
    [SerializeField] Image heroImage;
    [SerializeField] Text _caracLV;
    [SerializeField] Text _livetimetx;
    [SerializeField] Text _goldtx;
    [SerializeField] Text _killstx;
    [SerializeField] Text _damagestx;
    [SerializeField] Text _null;
    Hero _hero;
    private void Start()
    {
        Text();
        GenericSingleton<GameManager>.getInstance().Clear();
    }
    public void Text()
    {
        _caracLV.text = "·¹º§" + GenericSingleton<GameManager>.getInstance().HeroLv;
        _livetimetx.text =  $"{GenericSingleton<GameManager>.getInstance().SurviveTime.ToString("F1")}"+"ÃÊ »ýÁ¸" ;//$¹®Àº Çüº¯È¯¿¡»ç¿ë
        _goldtx.text = "È¹µæ°ñµå" + GenericSingleton<GameManager>.getInstance().StageGold;
        _killstx.text = "ÃÑÅ³" + GenericSingleton<GameManager>.getInstance().KillCount;
        _damagestx.text = "ÃÑµ¥¹ÌÁö" + GenericSingleton<GameManager>.getInstance().TotalDmg;
        _hero = new Hero();
        if (GenericSingleton<GameManager>.getInstance().HeroType == Define.HeroType.Wizard)
        {
            heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/WizardThumb", typeof(Sprite)) as Sprite;
        }
        if (GenericSingleton<GameManager>.getInstance().HeroType == Define.HeroType.SwordHero)
        {
            heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/SwordHeroThumb", typeof(Sprite)) as Sprite;
        }
    }
}
