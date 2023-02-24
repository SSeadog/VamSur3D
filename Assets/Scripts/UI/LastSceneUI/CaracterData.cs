using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CaracterData : MonoBehaviour
{

    [SerializeField] Text _caracLV;
    [SerializeField] Text _livetime;
    [SerializeField] Text _gold;
    [SerializeField] Text _kills;
    [SerializeField] Text _damages;
    [SerializeField] Text _null;
    SwordHeroMove hero;
    int LV = 0;
    float livetime = 0f;
    int gold = 0;
    int kills = 0;
    int damages = 0;
    private void Start()

    {
       livetime = PlayerPrefs.GetFloat("_lifetime");//PlayerPrefs.setint("�̸�"��),PlayerPrefs.getint("�����̸�")
        Debug.Log(livetime);
        text();
    }
    public void text()
    {
        _caracLV.text = "����" + LV;
        _livetime.text =   $"{livetime.ToString("F1")}"+"�� ����" ;
        _gold.text = "ȹ����" + gold;
        _kills.text = "��ų" + kills;
        _damages.text = "�ѵ�����" + damages;
    }
}
