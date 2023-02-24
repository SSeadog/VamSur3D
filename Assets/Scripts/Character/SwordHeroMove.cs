using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


enum ESwordHeroMove
{
    Idle,
    w,//forward
    a,//left
    s,//back
    d,//right
    die,

}
public class SwordHeroMove : MonoBehaviour
{
    Color heroColor;
    [SerializeField] SkinnedMeshRenderer _render;
    [SerializeField] Animator _ani;
    [SerializeField] GameObject _rotate;
    [SerializeField] GameObject _hero;
    [SerializeField] float _speed;//캐릭터 스택은 외부 파일에서 불러옴
    [SerializeField] int _hp;
    float _timer = 0f;
    float _dietimer = 0f;
    public float _lifetimer = 0f;
    bool _hit = false;
    bool _move = true;
    //public Dictionary<EItem, int> EItems = new Dictionary<EItem, int>();

    void Start()
    {
        heroColor = _render.material.color;
        Debug.Log("????");
    }

    void Update()
    {
        if (_move == true)
        {
            move();
            _lifetimer += Time.deltaTime;
        }
        if (_hit == false) Hitted();
        HittedColer();

    }
    public void move()
    {
        Vector3 v3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Debug.Log("forward");
        }
        if (Input.GetKey(KeyCode.A))
        {
            v3 += (Vector3.left).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
            Debug.Log("left");
        }
        if (Input.GetKey(KeyCode.S))
        {
            v3 += (Vector3.back).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            Debug.Log("back");
        }
        if (Input.GetKey(KeyCode.D))
        {
            v3 += (Vector3.right).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            Debug.Log("right");
        }
        if (v3 != Vector3.zero)
        {
            transform.Translate(v3);
        }
        else
        {
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.Idle);
        }
    }
    public void Hitted()
    {
        if (Input.GetKeyDown(KeyCode.M))//공격받았을때
        {
            _hp -= 20;
            _hit = true;
        }
        if (_hp <= 0)
        {
            Die();
        }
    }
    public void HittedColer()
    {
        if (_hit == true)
        {
            _timer += Time.deltaTime;
            _render.material.color = Color.red;
            if (_timer > 0.5f)
            {
                _render.material.color = heroColor;
                _timer = 0f;
                _hit = false;
            }
        }
    }
    public void Die()
    {
        _ani.SetInteger("SwordHero", (int)ESwordHeroMove.die);
        Debug.Log("Die");
        _move = false;
        NextScene();
        Debug.Log(_lifetimer);
        PlayerPrefs.SetFloat("_lifetime", _lifetimer);//씬 전환시 == 1복사파일에 저장후 원본이 파기됨
    }
    public void NextScene()
    {
        _dietimer += Time.deltaTime;
        if (_dietimer >= 1f)SceneManager.LoadScene("LastScene");
    }
}


