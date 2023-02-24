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
    public BoxInteractionUI boxInteractionUI;
    public GameOverUI gameOverUI;
    public ESCMenuUI eSCMenuUI;
    public SettingsUI settingsUI;

    void Start()
    {
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
