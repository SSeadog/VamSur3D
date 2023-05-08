using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CharacterBoxController : MonoBehaviour
{
    //��ü����Ʈ�� ����ְ� ������ ���ӿ�����Ʈ Ŭ���ϸ� ��ü���� ���� ���ӿ�����Ʈ�� ����

    //����������Ʈ������ �޾ƿͼ� ���� ���� ������Ʈ�� ����� ��� ����������Ʈ�� setactive(false)
    [SerializeField] MenuUIController _menuUIController;
    Transform cBeforeBoxInfo = null;
    GameObject childObject;

    int num = 1;
    public void isBeforeBoxInfo(SelectedInfoBox ib)
    {
        if (cBeforeBoxInfo == null)
        {
            cBeforeBoxInfo = ib.SelectBackground;
            return;
        }
        cBeforeBoxInfo.gameObject.SetActive(false);
        cBeforeBoxInfo = ib.SelectBackground;
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


} 
