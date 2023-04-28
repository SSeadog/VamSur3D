using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] GameObject CharacterMenuPanel;
    [SerializeField] GameObject CharacterInfoMenuPanel;
    [SerializeField] GameObject CharacterBox;
    [SerializeField] GameObject CharacterInfoBox;
    [SerializeField] Transform _characterContent;
    [SerializeField] GameObject WeaponUpgradeMenuPanel;
    [SerializeField] GameObject WeaponUpgradeInfoMenuPanel;
    [SerializeField] Transform _weaponUpgradeContent;




    // Start is called before the first frame update
    public void OnSelectCharacterMenu()
    {
        CharacterMenuPanel.SetActive(true);
        initSelectBox(CharacterMenuPanel);
    }

    public void OpenSelectCharacterPanel()
    {
        CharacterInfoMenuPanel.SetActive(true);
    }

    public void OnSelectWeaponUpgradeMenu()
    {
        WeaponUpgradeMenuPanel.SetActive(true);
        initSelectBox(WeaponUpgradeMenuPanel);
    }

    public void OpenWeaponUpgradePanel()
    {
        WeaponUpgradeInfoMenuPanel.SetActive(true);
    }

    public void initSelectBox(GameObject panel)
    {
        if (panel == CharacterMenuPanel)
        {
            for (int i = 0; i < 17; i++)
            {
                GameObject infoBoxTmp = Instantiate(CharacterBox, _characterContent);
                infoBoxTmp.GetComponent<SelectedInfoBox>().Init(panel.GetComponent<CharacterBoxController>());
                infoBoxTmp.name = "CharacterBox";
            }
        }
        else if (panel == WeaponUpgradeMenuPanel)
        {
            for (int i = 0; i < 17; i++)
            {
                GameObject infoBoxTmp = Instantiate(CharacterBox, _weaponUpgradeContent);
                infoBoxTmp.GetComponent<SelectedInfoBox>().Init(panel.GetComponent<CharacterBoxController>());
                infoBoxTmp.name = "CharacterBox";
            }
        }
    }

  

    public void initSelectedCharacter()
    {
        GameObject selectCharacterBoxTmp = Instantiate(CharacterInfoBox);
    }

    // MainStart 테스트코드
    public void TestStartMain()
    {
        GenericSingleton<GameManager>.getInstance().heroType = Define.HeroType.Wizard;
        SceneManager.LoadScene("MainScene");
    }
}
   
