using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenTest : MonoBehaviour
{
    [SerializeField] GameObject _butten;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onButtonPress()
    {
        Debug.Log("��ưȰ��ȭ");
        _butten.SetActive(true);
    }
        void Update()
    {
        
    }
}
