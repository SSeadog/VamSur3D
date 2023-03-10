using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


enum ECaracMove
{
    Idle,
    w,//forward
    a,//left
    s,//back
    d,//right
    die,

}
public class HeroMove : MonoBehaviour
{
    Color heroColor;
    [SerializeField] SkinnedMeshRenderer _render;
    [SerializeField] Animator _ani;
    [SerializeField] GameObject _rotate;
    [SerializeField] GameObject _Hero;
    [SerializeField] float _speed;//캐릭터 스택은 외부 파일에서 불러옴
    [SerializeField] int _hp;
    float _hittimer, _dietimer, _lifetimer = 0f;// _attacktimer틱마다
    int _totalDMG, _LV, _killcount, _exp = 0;
    int _power = 10;
    bool _hit = false;
    bool _move = true;

    void Start()
    {
        Define.HeroType heroType = Define.HeroType.SwordHero; // 로비씬에서 넘겨준 데이터를 활용할 것
        Define.Hero heroData = Managers.Data.GetHeroInfo(heroType);

        heroColor = _render.material.color;
        ExpKill(100, true);
    }

    void Update()
    {
        if (_move == true)
        {
            Move();
            _lifetimer += Time.deltaTime;
        }
        if (_hit == false) Hitted();
        HittedColer();
    }

    public void ExpKill(int exp, bool kill)
    {
        _exp = exp;
        if (_exp >= 100) _LV++;

        if (kill == true) _killcount++;
    }
    void Move()
    {
        float vX = Input.GetAxisRaw("Horizontal");//0=>1
        float vZ = Input.GetAxisRaw("Vertical");//GetAxis 0=0.1=0.2=0.3===1
        float _a = vX;
        float _b = vZ;
        _ani.SetFloat("AxisX", vX * _speed);
        _ani.SetFloat("AxisZ", vZ * _speed);
        float vY = GetComponent<Rigidbody>().velocity.y;
        Vector3 v3 = new Vector3(_a, 0, _b);
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        GetComponent<Rigidbody>().velocity = vYz;
        if (Input.anyKey)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
    }
    
    // 실제로 쓸 수 있게 수정
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
            _hittimer += Time.deltaTime;
            _render.material.color = Color.red;
            if (_hittimer > 0.5f)
            {
                _render.material.color = heroColor;
                _hittimer = 0f;
                _hit = false;
            }
        }
    }
    public void Die()
    {
        _ani.SetInteger("CaracMove", (int)ECaracMove.die);
        _move = false;
        NextScene();
    }
    public void NextScene()
    {
        PlayerPrefs.SetFloat("_lifetime", _lifetimer);//씬 전환시 == 1복사파일에 저장후 원본이 파기됨
        PlayerPrefs.SetInt("_totalDMG", _totalDMG);

        // 매니저로 관리할 예정
        PlayerPrefs.SetInt("_LV", _LV);
        PlayerPrefs.SetInt("_killcount", _killcount);
        _dietimer += Time.deltaTime;
        if (_dietimer >= 1f) SceneManager.LoadScene("LastScene");
    }
}


