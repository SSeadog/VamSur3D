using UnityEngine;
using UnityEngine.SceneManagement;
public class OpTion : MonoBehaviour
{
    [SerializeField] WeaponData _weapondata;
    [SerializeField] GameObject _butten;
    // Start is called before the first frame update
    void Start()
    {
        _weapondata.Startpanul();
        Debug.Log("OpTion");
    }
    public void onButtonPress()
    {
        Debug.Log("버튼활성화");
        GenericSingleton<GameManager>.getInstance().Clear();
        SceneManager.LoadScene("MenuScene"); //로비씬으로 
    }
}
