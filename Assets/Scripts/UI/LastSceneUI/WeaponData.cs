using System.Collections.Generic;
using UnityEngine;
public class WeaponData : MonoBehaviour
{
    [SerializeField] GameObject _item;
    [SerializeField] Transform _contentTransform;
    List<GameObject> lstItems = new List<GameObject>();
    public void StartPanul()//메게변수 획득아이템
    {
//        GenericSingleton<GameManager>.getInstance().GetCurrentWeaponLevel()
        _item.SetActive(true);
        for (int i = 1; i < 7; i++) //(int)EItem.max 를 아이템 획득 숫자로 변경
                  //지금 아무리봐도 무기를 레벨업해서 창뛰우고 선택하면 그무기를 가지고있던 기본은없애고 새로 값을받아서 만드는걸로만 보이는데 몇개를 가지고있느냐, 몇이상 못가진다 등은 없는걸로보임
                  //   foreach (ItemData data in _itemcsvcon.lstItemDates)
        {
            GameObject temp = Instantiate(_item, _contentTransform);
            temp.GetComponent<LastSceneItem>().init();
            lstItems.Add(temp);
            Debug.Log("Startpanul");
        }
    }
}
