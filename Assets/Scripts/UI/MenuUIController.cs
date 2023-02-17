using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Build.Content;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] GameObject selectCharacterMenu;
    [SerializeField] GameObject CharacterInfoMenu;
    [SerializeField] GameObject SelectedCharacterMenuInfoBox;
    [SerializeField] GameObject CharacterInfoMenuBox;
    [SerializeField] Transform _content;
    // Start is called before the first frame update
    public void OnSelectCharacterMenu()
    {
        selectCharacterMenu.SetActive(true);
        initSelectBox();
    }

    public void OnSelectCharacter()
    {
        CharacterInfoMenu.SetActive(true);
        initSelectedCharacter();
    }

    public void initSelectBox()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject infoBoxTmp = Instantiate(SelectedCharacterMenuInfoBox, _content);
        }
    }

    public void initSelectedCharacter()
    {
        GameObject selectCharacterBoxTmp = Instantiate(CharacterInfoMenuBox);
    }

    
}
