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
        _caracLV.text = "·¹º§" + GenericSingleton<GameManager>.getInstance().heroLv;
        _livetimetx.text =  $"{GenericSingleton<GameManager>.getInstance().surviveTime.ToString("F1")}"+"ÃÊ »ýÁ¸" ;//$¹®Àº Çüº¯È¯¿¡»ç¿ë
        _goldtx.text = "È¹µæ°ñµå" + GenericSingleton<GameManager>.getInstance().stageGold;
        _killstx.text = "ÃÑÅ³" + GenericSingleton<GameManager>.getInstance().killCount;
        _damagestx.text = "ÃÑµ¥¹ÌÁö" + GenericSingleton<GameManager>.getInstance().totalDmg;
        _hero = new Hero();
        if (GenericSingleton<GameManager>.getInstance().heroType == Define.HeroType.Wizard)
        {
            heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/WizardThumb", typeof(Sprite)) as Sprite;
        }
        if (GenericSingleton<GameManager>.getInstance().heroType == Define.HeroType.SwordHero)
        {
            heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/SwordHeroThumb", typeof(Sprite)) as Sprite;
        }
    }
}
