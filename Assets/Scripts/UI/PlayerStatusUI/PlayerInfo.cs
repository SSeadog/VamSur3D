using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    string _thumbnailPath;
    int _lv;

    Image _thumbnailImage;
    TMP_Text _lvText;

    public void Init()
    {
        _thumbnailImage = transform.Find("ThumbFrame/Thumbnail").GetComponent<Image>();
        _lvText = transform.Find("LvFrame/LvText").GetComponent<TMP_Text>();
    }

    void Start()
    {
        Init();
    }

    public void SetThumbnail(string path)
    {
        _thumbnailPath = path;
        Sprite thumb = Resources.Load<Sprite>(_thumbnailPath);
        _thumbnailImage.sprite = thumb;
    }

    public void SetLv(int lv)
    {
        _lv = lv;
        _lvText.text = _lv.ToString();
    }
}
