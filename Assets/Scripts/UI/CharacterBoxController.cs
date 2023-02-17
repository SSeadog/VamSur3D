using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CharacterBoxController : MonoBehaviour
{
    //��ü����Ʈ�� ����ְ� ������ ���ӿ�����Ʈ Ŭ���ϸ� ��ü���� ���� ���ӿ�����Ʈ�� ����

    //����������Ʈ������ �޾ƿͼ� ���� ���� ������Ʈ�� ����� ��� ����������Ʈ�� setactive(false)
    [SerializeField]    MenuUIController _menuUIController;
    public Transform BeforeBoxInfo = null;

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
} 
