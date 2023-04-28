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
    [SerializeField] Transform _weaponContent;




    // Start is called before the first frame update
    public void OnSelectCharacterMenu()
    {
        CharacterMenuPanel.SetActive(true);
        initSelectBox();
    }

    public void OpenSelectCharacterPanel()
    {
        CharacterInfoMenuPanel.SetActive(true);
    }

    public void OpenWeaponUpgradePanel()
    {
        WeaponUpgradeMenuPanel.SetActive(true);
    }

    public void initSelectBox()
    {
        for (int i = 0; i < 17; i++)
        {
            
            GameObject infoBoxTmp = Instantiate(CharacterBox, _characterContent);
            infoBoxTmp.GetComponent<SelectedInfoBox>().Init(CharacterMenuPanel.GetComponent<CharacterBoxController>());
            infoBoxTmp.name = "CharacterBox";
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
   
