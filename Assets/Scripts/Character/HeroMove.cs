using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.VFX;

enum EHeroMove
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
    [SerializeField] float _speed;//ĳ���� ������ �ܺ� ���Ͽ��� �ҷ���
    [SerializeField] int _hp;
    float _hittimer, _dietimer, _lifetimer = 0f;// _attacktimerƽ����
    int _totalDMG, _LV, _killcount, _exp = 0;
    int _power = 10;
    bool _hit = false;
    bool _move = true;
    Vector3 fors;

    void Start()
    {
        Define.HeroType heroType = Define.HeroType.SwordHero; // �κ������ �Ѱ��� �����͸� Ȱ���� ��
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
        float vX = Input.GetAxisRaw("Horizontal");//0=>1D==     -1,1,0���� ��ӵ���
        float vZ = Input.GetAxisRaw("Vertical");//GetAxis 0=0.1=0.2=0.3===1
        Debug.Log(vX);
        Debug.Log(vZ);
        _ani.SetFloat("AxisX", vX * _speed);
        _ani.SetFloat("AxisZ", vZ * _speed);
        float vY = GetComponent<Rigidbody>().velocity.y;
        Vector3 v3 = new Vector3(vX, 0, vZ);
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        GetComponent<Rigidbody>().velocity = vYz;
        if (Input.GetButton("Horizontal") && vX != 0) 
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));   
        }
        if (Input.GetButton("Vertical")&& vZ != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
    }

    // ������ �� �� �ְ� ����
    public void Hitted()
    {
        if (Input.GetKeyDown(KeyCode.M))//���ݹ޾�����
        {
            _hp -= 20;
            _hit = true;
        }
        if (_hp <= 0)
        {
            if (_move == true)
            {
                 fors = gameObject.transform.position;
            }
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
        _ani.SetInteger("HeroMove", (int)EHeroMove.die);
        _move = false;
        gameObject.transform.position = fors;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        NextScene();
    }
    public void NextScene()
    {
        PlayerPrefs.SetFloat("_lifetime", _lifetimer);//�� ��ȯ�� == 1�������Ͽ� ������ ������ �ı��
        PlayerPrefs.SetInt("_totalDMG", _totalDMG);

        // �Ŵ����� ������ ����
        PlayerPrefs.SetInt("_LV", _LV);
        PlayerPrefs.SetInt("_killcount", _killcount);
        _dietimer += Time.deltaTime;
        if (_dietimer >= 1f) SceneManager.LoadScene("LastScene");
    }
}


