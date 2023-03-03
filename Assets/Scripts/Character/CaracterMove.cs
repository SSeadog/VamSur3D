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
public class CaracterMove: MonoBehaviour
{
    Color heroColor;
    [SerializeField] SkinnedMeshRenderer _render;
    [SerializeField] Animator _ani;
    [SerializeField] GameObject _rotate;
    [SerializeField] GameObject _character;
    [SerializeField] float _speed;//ĳ���� ������ �ܺ� ���Ͽ��� �ҷ���
    [SerializeField] int _hp;
    float _hittimer, _attacktimer, _dietimer, _lifetimer = 0f;// _attacktimerƽ����
    int _totalDMG, _LV, _killcount, _exp = 0;
    int _power = 10;
    bool _hit = false;
    bool _move = true;
    //public Dictionary<EItem, int> EItems = new Dictionary<EItem, int>();

    void Start()
    {
        heroColor = _render.material.color;
        EXPKill(100, true);
    }

    void Update()
    {
       // if (_move == true)
        {
            move();
            _lifetimer += Time.deltaTime;
            _attacktimer += Time.deltaTime;
        }
        if (_hit == false) Hitted();
        HittedColer();
        Attack(_power);
    }

    public void Attack(int power)
    {
        if (_attacktimer >= 1f)
        {
            _totalDMG += power;
            Debug.Log(_totalDMG);
            _attacktimer = 0f;
        }
    }
    public void EXPKill(int exp, bool kill)
    {
        _exp = exp;
        if (_exp >= 100) _LV++;


        if (kill == true) _killcount++;
    }
    public void move()
    {
        Vector3 v3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("CaracMove", (int)ECaracMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Debug.Log("forward");
        }
        if (Input.GetKey(KeyCode.A))
        {
            v3 += (Vector3.left).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("CaracMove", (int)ECaracMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
            Debug.Log("left");
        }
        if (Input.GetKey(KeyCode.S))
        {
            v3 += (Vector3.back).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("CaracMove", (int)ECaracMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            Debug.Log("back");
        }
        if (Input.GetKey(KeyCode.D))
        {
            v3 += (Vector3.right).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("CaracMove", (int)ECaracMove.w);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            Debug.Log("right");
        }
        if (v3 != Vector3.zero)
        {
            transform.Translate(v3);
        }
        else
        {
            _ani.SetInteger("CaracMove", (int)ECaracMove.Idle);
        }
    }
    public void Hitted()
    {
        if (Input.GetKeyDown(KeyCode.M))//���ݹ޾�����
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
        Debug.Log("Die");
        _move = false;
        NextScene();
        Debug.Log(_lifetimer);
    }
    public void NextScene()
    {
        PlayerPrefs.SetFloat("_lifetime", _lifetimer);//�� ��ȯ�� == 1�������Ͽ� ������ ������ �ı��
        PlayerPrefs.SetInt("_totalDMG", _totalDMG);
        PlayerPrefs.SetInt("_LV", _LV);
        PlayerPrefs.SetInt("_killcount", _killcount);
        _dietimer += Time.deltaTime;
        if (_dietimer >= 1f) SceneManager.LoadScene("LastScene");
    }
}

