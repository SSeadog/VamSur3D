using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
   
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
    [SerializeField] Item _controllor;
    public void ShowSkillPanel()
    {
        gameObject.SetActive(true);
        foreach (ItemDate data in _controllor.lstItemDate)
        {
            GameObject temp = Instantiate(_item, _content);
            temp.GetComponent<ItemDate>().init(data);
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
