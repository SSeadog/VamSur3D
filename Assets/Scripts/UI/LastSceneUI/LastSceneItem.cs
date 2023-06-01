using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class LastSceneItem : MonoBehaviour
{
    List<Define.WeaponType> keys = GenericSingleton<GameManager>.getInstance().GetCurrentWeaponList();

    //�ʿ��Ѱ� ȹ�� ����, ������
    [SerializeField] Image _Image;
    [SerializeField] Text _name;
    [SerializeField] Text _lv;
    [SerializeField] Text _dmg;
    // public void init(ItemData data, WeaponData weaponData)//�������� �޾Ƽ� ��°� ����
    public void init()//�������� �޾Ƽ� ��°� ����
    {
        _name.text = "" +GenericSingleton<GameManager>.getInstance().name;
       // _lv.text = " LV." + GenericSingleton<GameManager>.getInstance().HeroLv;
        _dmg.text = "���ⵥ���� : " + GenericSingleton<GameManager>.getInstance().TotalDmg;
        foreach (Define.WeaponType key in keys)
        {
            int level = (int)key;
            Define.Weapon data = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(key, level);
             Debug.Log(data.lv);//ó���� 2���� ������
             Debug.Log(data.power);//
             Debug.Log(data.thumbnailPath);//
            _lv.text = "���� ���� :"+data.lv.ToString();
            _Image.sprite = Resources.Load(data.thumbnailPath, typeof(Sprite)) as Sprite;
            _name.text = data.power.ToString();
            _dmg.text = "���� ���ݷ� :"+ data.power.ToString();


        }
    }
}
