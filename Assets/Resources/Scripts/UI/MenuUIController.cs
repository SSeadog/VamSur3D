using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    [SerializeField]
    GameObject selectCharacterMenu;
    // Start is called before the first frame update
    public void OnSelectCharacterMenu()
    {
        selectCharacterMenu.SetActive(true);

    }

    
}
