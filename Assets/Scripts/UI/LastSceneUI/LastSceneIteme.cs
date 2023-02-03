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
        _name.text = "무기이름" + data.NAME;
        _lv.text = " LV." + data.LV;  
        _dmg.text = "데미지 : " + data.DMG ;
        _dps.text = " DPS: " + data.DPS  ;
        _kills.text = " 킬수: " + data.KILLS;
    }
  
}
