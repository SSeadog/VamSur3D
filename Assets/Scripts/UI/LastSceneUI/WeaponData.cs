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
    public void Startpanul()//�ްԺ��� ȹ�������
    {
        _item.SetActive(true);
        for (int i = 1; i < 7; i++) //(int)EItem.max �� ������ ȹ�� ���ڷ� ����
                                                 //   foreach (ItemData data in _itemcsvcon.lstItemDates)
        {
            GameObject temp = Instantiate(_item, _content);
            temp.GetComponent<LastSceneIteme>().init();
            lstItems.Add(temp);
            Debug.Log("Startpanul");
        }
    }
}
