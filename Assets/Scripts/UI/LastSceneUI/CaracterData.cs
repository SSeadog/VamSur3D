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
        _caracLV.text = "����" + Managers.Game.heroLv;
        _livetimetx.text =  $"{Managers.Game.surviveTime.ToString("F1")}"+"�� ����" ;//$���� ����ȯ�����
        _goldtx.text = "ȹ����" + Managers.Game.stageGold;
        _killstx.text = "��ų" + Managers.Game.killCount;
        _damagestx.text = "�ѵ�����" + Managers.Game.totalDmg;
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
