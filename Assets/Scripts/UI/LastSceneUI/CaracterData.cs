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
        Managers.Game.Clear();
    }
    public void Text()
    {
        _caracLV.text = "·¹º§" + Managers.Game.heroLv;
        _livetimetx.text =  $"{Managers.Game.surviveTime.ToString("F1")}"+"ÃÊ »ýÁ¸" ;//$¹®Àº Çüº¯È¯¿¡»ç¿ë
        _goldtx.text = "È¹µæ°ñµå" + Managers.Game.stageGold;
        _killstx.text = "ÃÑÅ³" + Managers.Game.killCount;
        _damagestx.text = "ÃÑµ¥¹ÌÁö" + Managers.Game.totalDmg;
        _hero = new Hero();
        if (Managers.Game.heroType == Define.HeroType.Wizard)
        {
            heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/WizardThumb", typeof(Sprite)) as Sprite;
        }
        if (Managers.Game.heroType == Define.HeroType.SwordHero)
        {
            heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/SwordHeroThumb", typeof(Sprite)) as Sprite;
        }
    }
}
