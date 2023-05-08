using UnityEngine;
using UnityEngine.UI;

public class CaracterData : MonoBehaviour
{
    [SerializeField] Image heroImage;
    [SerializeField] Text _characterLVTXT;
    [SerializeField] Text _liveTimeTXT;
    [SerializeField] Text _goldTXT;
    [SerializeField] Text _killsTXT;
    [SerializeField] Text _damagesTXT;
    [SerializeField] Text vacantTXT;
    private void Start()
    {
        Text();
        GenericSingleton<GameManager>.getInstance().Clear();
    }
    public void Text()
    {
        _characterLVTXT.text = "·¹º§" + GenericSingleton<GameManager>.getInstance().HeroLv;
        _liveTimeTXT.text =  $"{GenericSingleton<GameManager>.getInstance().SurviveTime.ToString("F1")}"+"ÃÊ »ýÁ¸" ;//$¹®Àº Çüº¯È¯¿¡»ç¿ë
        _goldTXT.text = "È¹µæ°ñµå" + GenericSingleton<GameManager>.getInstance().StageGold;
        _killsTXT.text = "ÃÑÅ³" + GenericSingleton<GameManager>.getInstance().KillCount;
        _damagesTXT.text = "ÃÑµ¥¹ÌÁö" + GenericSingleton<GameManager>.getInstance().TotalDmg;
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
