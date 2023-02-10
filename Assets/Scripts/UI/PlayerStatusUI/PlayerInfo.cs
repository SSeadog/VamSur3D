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
        _thumbnailImage = transform.Find("ThumbnailFrame/Thumbnail").GetComponent<Image>();
        _lvText = transform.Find("LvFrame/LvText").GetComponent<TMP_Text>();
    }

    public void SetThumbnail(string path)
    {
        _thumbnailPath = path;
    }

    public void SetLv(int lv)
    {
        _lv = lv;
    }
}
