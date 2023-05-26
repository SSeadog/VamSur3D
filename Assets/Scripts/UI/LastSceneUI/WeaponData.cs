using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

public class WeaponData : MonoBehaviour
{
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
   // [SerializeField] ItemCsvCon _itemcsvcon;
    [SerializeField] GameObject _buttest;
    List<GameObject> lstItems = new List<GameObject>();
    public void Startpanul()//메게변수 획득아이템
    {
        _item.SetActive(true);
        for (int i = 1; i < 7; i++) //(int)EItem.max 를 아이템 획득 숫자로 변경
                                                 //   foreach (ItemData data in _itemcsvcon.lstItemDates)
        {
            GameObject temp = Instantiate(_item, _content);
            temp.GetComponent<LastSceneIteme>().init();
            lstItems.Add(temp);
            Debug.Log("Startpanul");
        }
    }
}
