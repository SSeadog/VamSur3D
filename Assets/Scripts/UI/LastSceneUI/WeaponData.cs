using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    [SerializeField] GameObject _itemcan;
    [SerializeField] Transform _content;
    [SerializeField] ItemCsvCon _itemcontrol;
    [SerializeField] ListData _listdata;
    List<GameObject> lstItems = new List<GameObject>();
    void Start()
    {
        for (int i = 1; i < (int)EItem.max; i++) //5����
        {
            foreach (ItemData data in _itemcontrol.lstItemDate)  //   foreach (  data dp  in <=�̰��� ����Ʈ������ 1,2,3,4,   ) 
            {
                if (data.ETYPE != (EItem)i) continue;//data.ETYPE�� (EItem)i�� �ƴϸ� ��������

                if (_listdata.EItems.ContainsKey(data.ETYPE) == true)//_hero.dicSkills.ContainsKey(data.ETYPE)�� == true�� �Ʒ��������
                {
                    if (data.INDEX == _listdata.EItems[data.ETYPE] + 1)
                    {
                        GameObject temp = Instantiate(_itemcan, _content);
                        temp.GetComponent<LastSceneIteme>().init(data);
                        lstItems.Add(temp);
                    }
                }
                else
                {
                    GameObject temp = Instantiate(_itemcan, _content);
                    temp.GetComponent<LastSceneIteme>().init(data);
                    lstItems.Add(temp);
                }
            }
        }
    }

    void Update()
    {

    }
}
