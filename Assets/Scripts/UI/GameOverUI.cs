using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    // Todo
    // Manager에서 GameEnd 플래그 만들면 해당 플래그에 맞게 로드하기
    bool isGameEnd = false;

    Button _quitButton;

    float _fadeDuration = 0.25f;
    float _fadeTImer = 0f;

    Image[] _images;
    float[] _imgAlphas;

    public void Init()
    {
        _quitButton = GetComponentInChildren<Button>();
        _quitButton.onClick.AddListener(() => { OnQuitButtonClicked(); });

        _images = GetComponentsInChildren<Image>();
        _imgAlphas = new float[_images.Length];
        for (int i = 0; i < _images.Length; i++)
        {
            _imgAlphas[i] = _images[i].color.a;
        }
    }

    public void ShowUI()
    {
        gameObject.SetActive(true);
    }

    IEnumerator FadeUI()
    {
        while (_fadeTImer < _fadeDuration)
        {
            _fadeTImer += Time.deltaTime;

            foreach(Image img in _images)
            {
                // 기본 알파값에 _fadeTImer이용해서 적절한 값 곱해주기
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void OnQuitButtonClicked()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
