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
    public void init(ItemDate data)
    {
        _name.text = "�����̸�" + data.NAME;
        _lv.text = " LV." + data.LV;  
        _dmg.text = "������ : " + data.DMG ;
        _dps.text = " DPS: " + data.DPS  ;
        _kills.text = " ų��: " + data.KILLS;
    }
  
}
