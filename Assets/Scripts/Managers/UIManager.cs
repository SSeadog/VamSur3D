using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerStatusUI playerStatusUI;
    public PlayerHPBarUI playerHPBarUI;
    public PlayerExpBarUI playerExpBarUI;
    public KillCountUI killCountUI;
    public MoneyUI moneyUI;
    public WeaponSelectUI weaponSelectUI;
    public GameOverUI gameOverUI;
    public ESCMenuUI eSCMenuUI;
    public SettingsUI settingsUI;

    private void Start()
    {
        Managers.Game.uIManager = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (eSCMenuUI.gameObject.activeSelf == false)
                eSCMenuUI.ShowUI();
            else
                eSCMenuUI.CloseUI();
        }
    }
}
