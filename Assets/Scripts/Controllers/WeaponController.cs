using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    GameObject _weaponRoot;
    void Start()
    {
        foreach (Transform tr in transform.GetComponentInChildren<Transform>())
        {
            if (tr.name == "WeaponRoot")
            {
                _weaponRoot = tr.gameObject;
            }
        }

        if ( _weaponRoot == null )
        {
            Debug.Log("WeaponRoot 없음");
        }

        // 얻은 무기 로드
        // 지금은 테스트
        List<string> paths = new List<string>();
        paths.Add("Prefabs/Weapons/TestBow/TestBow");
        paths.Add("Prefabs/Weapons/TestWeapon/TestWeapon");
        for (int i = 0; i < paths.Count; i++)
        {
            GameObject ori = Resources.Load<GameObject>(paths[i]);
            GameObject instance = Instantiate(ori, _weaponRoot.transform);
            instance.GetComponent<WeaponBase>().Init();
        }
    }
}
