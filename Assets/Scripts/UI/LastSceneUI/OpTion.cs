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
        Debug.Log("��ưȰ��ȭ");
        GenericSingleton<GameManager>.getInstance().Clear();
        SceneManager.LoadScene("MenuScene"); //�κ������ 
    }
}
