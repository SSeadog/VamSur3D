using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class LastSceneItem : MonoBehaviour
{
    List<Define.WeaponType> keys = GenericSingleton<GameManager>.getInstance().GetCurrentWeaponList();

    //필요한거 획득 숫자, 데이터
    [SerializeField] Image _Image;
    [SerializeField] Text _name;
    [SerializeField] Text _lv;
    [SerializeField] Text _dmg;
    // public void init(ItemData data, WeaponData weaponData)//무기정보 받아서 출력값 변경
    public void init()//무기정보 받아서 출력값 변경
    {
        _name.text = "" +GenericSingleton<GameManager>.getInstance().name;
       // _lv.text = " LV." + GenericSingleton<GameManager>.getInstance().HeroLv;
        _dmg.text = "무기데미지 : " + GenericSingleton<GameManager>.getInstance().TotalDmg;
        foreach (Define.WeaponType key in keys)
        {
            int level = (int)key;
            Define.Weapon data = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(key, level);
             Debug.Log(data.lv);//처음에 2부터 시작함
             Debug.Log(data.power);//
             Debug.Log(data.thumbnailPath);//
            _lv.text = "무기 레벨 :"+data.lv.ToString();
            _Image.sprite = Resources.Load(data.thumbnailPath, typeof(Sprite)) as Sprite;
            _name.text = data.power.ToString();
            _dmg.text = "무기 공격력 :"+ data.power.ToString();


        }
    }
}
