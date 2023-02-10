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
        for (int i = 1; i < (int)EItem.max; i++) //5까지
        {
            foreach (ItemData data in _itemcontrol.lstItemDate)  //   foreach (  data dp  in <=이곳에 리스트정보를 1,2,3,4,   ) 
            {
                if (data.ETYPE != (EItem)i) continue;//data.ETYPE이 (EItem)i이 아니면 다음으로

                if (_listdata.EItems.ContainsKey(data.ETYPE) == true)//_hero.dicSkills.ContainsKey(data.ETYPE)가 == true면 아래문장실행
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
