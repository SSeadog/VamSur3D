using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCMenuUI : PopupUIBase
{
    // Todo
    // Fade ȿ?? ?ֱ?

    Button _resumeButton;
    Button _settingsButton;
    Button _exitButton;

    SettingsUI _settingsUI;

    public override void Init()
    {
        base.Init();

        _resumeButton = transform.Find("Panel/ResumeButton").GetComponent<Button>();
        _settingsButton = transform.Find("Panel/SettingsButton").GetComponent<Button>();
        _exitButton = transform.Find("Panel/ExitButton").GetComponent<Button>();

        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);

        _settingsUI = GameObject.Find("UIRoot").transform.Find("SettingsUI").GetComponent<SettingsUI>();
        _settingsUI.Init(this);
    }

    void OnResumeButtonClicked()
    {
        CloseUI();
    }

    void OnSettingsButtonClicked()
    {
        _settingsUI.ShowUI();
    }

    void OnExitButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
