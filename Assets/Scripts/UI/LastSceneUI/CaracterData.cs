using UnityEngine;
using UnityEngine.UI;

public class CaracterData : MonoBehaviour
{

    [SerializeField] Text _caracLV;
    [SerializeField] Text _livetimetx;
    [SerializeField] Text _goldtx;
    [SerializeField] Text _killstx;
    [SerializeField] Text _damagestx;
    [SerializeField] Text _null;
    int _LV = 0;
    float _livetime = 0f;
    int _gold = 0;
    int _kills = 0;
    int _damages = 0;
    private void Start()

    {
       _livetime = PlayerPrefs.GetFloat("_lifetime");//PlayerPrefs.setint("이름"값),PlayerPrefs.getint("받을이름")
       _damages = PlayerPrefs.GetInt("_totalDMG");
        _LV = PlayerPrefs.GetInt("_LV");
        _kills = PlayerPrefs.GetInt("_killcount");
        Debug.Log(_livetime);
        Text();
    }
    public void Text()
    {
        _caracLV.text = "레벨" + _LV;
        _livetimetx.text =  $"{GenericSingleton<GameManager>.getInstance().surviveTime.ToString("F1")}"+"초 생존" ;//$문은 형변환에사용
        _goldtx.text = "획득골드" + _gold;
        _killstx.text = "총킬" + _kills;
        _damagestx.text = "총데미지" + _damages;
    }
}
