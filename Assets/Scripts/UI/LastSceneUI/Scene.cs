using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
   
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
    [SerializeField] ItemCsvCon _itemcon;
    List<GameObject> lstItems = new List<GameObject>();
    public void ShowSkillPanel()
    {
        gameObject.SetActive(true);
        foreach (ItemData data in _itemcon.lstItemDate)
        {
            GameObject temp = Instantiate(_item, _content);
         //   temp.GetComponent<ItemData>().init(data);
            lstItems.Add(temp);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
