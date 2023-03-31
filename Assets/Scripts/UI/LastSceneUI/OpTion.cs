using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpTion : MonoBehaviour
{
    [SerializeField] WeaponData _weapondata;
    [SerializeField] GameObject _butten;
    // Start is called before the first frame update
    void Start()
    {
        _weapondata.Startpanul();
    }
    public void onButtonPress()
    {
        Debug.Log("버튼활성화");
        //로비씬으로 
        SceneManager.LoadScene("MenuScene");
    }
  
}
