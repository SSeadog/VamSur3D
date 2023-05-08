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
        _characterLVTXT.text = "����" + GenericSingleton<GameManager>.getInstance().heroLv;
        _liveTimeTXT.text =  $"{GenericSingleton<GameManager>.getInstance().surviveTime.ToString("F1")}"+"�� ����" ;//$���� ����ȯ�����
        _goldTXT.text = "ȹ����" + GenericSingleton<GameManager>.getInstance().stageGold;
        _killsTXT.text = "��ų" + GenericSingleton<GameManager>.getInstance().killCount;
        _damagesTXT.text = "�ѵ�����" + GenericSingleton<GameManager>.getInstance().totalDmg;
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
