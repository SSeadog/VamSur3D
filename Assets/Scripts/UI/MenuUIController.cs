using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] GameObject CharacterMenuPanel;
    [SerializeField] GameObject CharacterInfoMenuPanel;
    [SerializeField] GameObject CharacterBox;
    [SerializeField] GameObject CharacterInfoBox;
    [SerializeField] Transform _characterContent;
    [SerializeField] GameObject WeaponUpgradeMenuPanel;
    [SerializeField] GameObject WeaponBox;
    [SerializeField] Transform _weaponContent;
    [SerializeField] GameObject WeaponSelectPanel;
    [SerializeField] GameObject _settingsMenu;

    // Start is called before the first frame update
    public void OnSelectCharacterMenu()
    {
        CharacterMenuPanel.SetActive(true);
        initCharaterSelectBox();
    }

    public void OpenSelectCharacterPanel()
    {
        CharacterInfoMenuPanel.SetActive(true);
    }

    public void OnSelectWeaponUpgradeMenu()
    {
        WeaponUpgradeMenuPanel.SetActive(true);
        initWeaponSelectBox();
    }

    public void OnSettingsMenu()
    {
        _settingsMenu.SetActive(true);
    }

    public void OpenSelectWeaponPanel(Define.WeaponType type)
    {
        WeaponSelectPanel.SetActive(true);
        WeaponSelectPanel.GetComponent<WeaponInfoMenu>().SetData(type);
    }

    public void initCharaterSelectBox()
    {
        for (int i = 0; i < 17; i++)
        {
            
            GameObject infoBoxTmp = Instantiate(CharacterBox, _characterContent);
            infoBoxTmp.GetComponent<SelectedInfoBox>().Init(CharacterMenuPanel.GetComponent<CharacterBoxController>());
            infoBoxTmp.name = "CharacterBox";

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((eventData) => { infoBoxTmp.GetComponent<SelectedInfoBox>().OnClickedCharacterBox(); });

            infoBoxTmp.GetComponent<EventTrigger>().triggers.Add(entry);
        }
    }

    public void initWeaponSelectBox()
    {
        // 무기 개수만큼 로드하고 데이터도 전달하기
        List<Define.WeaponType> weaponTypes = new List<Define.WeaponType>(GenericSingleton<DataManager>.getInstance().WeaponDict.Keys);
        foreach (Define.WeaponType weaponType in weaponTypes)
        {
            Define.Weapon weaponInfo = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(weaponType);
            int curEnhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(weaponType);

            GameObject infoBoxTmp = Instantiate(WeaponBox, _weaponContent);
            infoBoxTmp.GetComponent<SelectedInfoBox>().Init(WeaponUpgradeMenuPanel.GetComponent<WeaponBoxController>());
            infoBoxTmp.GetComponent<SelectedInfoBox>().SetData(weaponInfo.thumbnailPath, weaponType.ToString());
            infoBoxTmp.name = "WeaponBox";

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((eventData) => { infoBoxTmp.GetComponent<SelectedInfoBox>().OnClickedWeaponBox(); });

            infoBoxTmp.GetComponent<EventTrigger>().triggers.Add(entry);
        }
    }

    public void initSelectedCharacter()
    {
        GameObject selectCharacterBoxTmp = Instantiate(CharacterInfoBox);
    }

    // MainStart 테스트코드
    //캐릭터 선택된 정보 메인씬으로 전달
    public void TestStartMain()
    {
        GenericSingleton<GameManager>.getInstance().GameStart(Define.HeroType.Wizard);
        SceneManager.LoadScene("MainScene");
    }
}
   
