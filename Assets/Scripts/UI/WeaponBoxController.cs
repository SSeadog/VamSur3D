using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxController : MonoBehaviour
{
    [SerializeField] MenuUIController _menuUIController;
    GameObject childObject;
    Transform wBeforeBoxInfo = null;

    public void isBeforeBoxInfo(SelectedInfoBox ib)
    {
        if (wBeforeBoxInfo == null)
        {
            wBeforeBoxInfo = ib.SelectBackground;
            return;
        }
        wBeforeBoxInfo.gameObject.SetActive(false);
        wBeforeBoxInfo = ib.SelectBackground;
    }
    public void getMenuUIControllerData()
    {
        _menuUIController.OpenSelectWeaponPanel();
    }

    public void OnReturnMainMenuButtonFromWeaponInfoMenu()
    {
        childObject = transform.Find("WeaponInfoMenu").gameObject;
        childObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
