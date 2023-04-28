using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CharacterBoxController : MonoBehaviour
{
    //전체리스트에 집어넣고 지금의 게임오브젝트 클릭하면 전체끄고 지금 게임오브젝트만 실행

    //이전오브젝트정보를 받아와서 지금 현재 오브젝트가 실행될 경우 이전오브젝트의 setactive(false)
    [SerializeField] MenuUIController _menuUIController;
    public Transform BeforeBoxInfo = null;
    GameObject childObject;

    int num = 1;
    public void isBeforeBoxInfo(SelectedInfoBox ib)
    {
        if (BeforeBoxInfo == null)
        {
            BeforeBoxInfo = ib.selectedBackground;
            return;
        }
        BeforeBoxInfo.gameObject.SetActive(false);
        BeforeBoxInfo = ib.selectedBackground;

    }

    public void getMenuUIControllerData()
    {
        _menuUIController.OpenSelectCharacterPanel();
    }

    public void OnReturnMainMenuButtonFromCharacterInfoMenu()
    {
        childObject = transform.Find("CharacterInfoMenu").gameObject;
        childObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void OnReturnMainMenuButtonFromWeaponInfoMenu()
    {
        childObject = transform.Find("WeaponInfoMenu").gameObject;
        childObject.SetActive(false);
        gameObject.SetActive(false);
    }
} 
