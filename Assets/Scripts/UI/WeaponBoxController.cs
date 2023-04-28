using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxController : MonoBehaviour
{
    [SerializeField] MenuUIController _menuUIController;
    public Transform wBeforeBoxInfo = null;
    GameObject childObject;
    public void isBeforeBoxInfo(SelectedInfoBox ib)
    {
        if (wBeforeBoxInfo == null)
        {
            wBeforeBoxInfo = ib.selectedBackground;
            return;
        }
        wBeforeBoxInfo.gameObject.SetActive(false);
        wBeforeBoxInfo = ib.selectedBackground;
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
