using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastSceneIteme : MonoBehaviour
{
    [SerializeField] Image _Image;
    [SerializeField] Text _name;
    [SerializeField] Text _lv;
    [SerializeField] Text _dmg;
    [SerializeField] Text _dps;
    [SerializeField] Text _kills;
    WeaponData _weaponData;
    ItemData _data;
    float time;
    public void init(ItemData data, WeaponData weaponData)//�������� �޾Ƽ� ��°� ����
    {
       // _data = data;
        _weaponData = weaponData;
        _name.text = data.NAME;
        _lv.text = " LV." + data.LV;  
        _dmg.text = "���ⵥ���� : " + data.DMG ;
        _dps.text = " DPS: " + data.DPS  ;
        _kills.text = " ų��: " + data.KILLS;
        Debug.Log("init");
    }

}
