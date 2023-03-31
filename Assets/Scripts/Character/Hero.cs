using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Analytics;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using static Define;
using static UnityEngine.UI.CanvasScaler;

enum EHeroMove
{
    Idle,
    w,//forward
    a,//left
    s,//back
    d,//right
    die,

}
public class Hero : MonoBehaviour
{
    HeroState _heroState;
    public Color heroColor;
    [SerializeField] public SkinnedMeshRenderer _render;
    [SerializeField] public Animator _ani;
    [SerializeField] GameObject _rotate;
    [SerializeField] GameObject _Hero;
    [SerializeField] public float _speed;//ĳ���� ������ �ܺ� ���Ͽ��� �ҷ���
    [SerializeField] public int _hp;
    public float _dietimer, _lifetimer, _hittimer = 0f;// _attacktimerƽ����
    public int _totalDMG, _LV, _killcount, _exp = 0;
    public int _hittidpowor=20;
    public bool _hit = false;
    public Vector3 fors;

    void Start()
    {
        // _heroState = new HeroMove();

        //Define.HeroType heroType = Define.HeroType.SwordHero; // �κ������ �Ѱ��� �����͸� Ȱ���� ��
        //Define.Hero heroData = Managers.Data.GetHeroInfo(heroType);
        //Managers.Data.GetHeroInfo(heroType);
        //heroColor = _render.material.color;
        // ExpKill(100, true);

        SetStateMove(new HeroMove());// ���� ����,����
        Managers.Game.player = gameObject;
    }
    void Update()
    {
        {
            _heroState.NowState();
            _lifetimer += Time.deltaTime;
        }
        _heroState.HittedColer();

        // ����ġ ȹ�� �ӽ� �ڵ�
        if (Input.GetKeyDown(KeyCode.E))
            Managers.Game.GetExp(10);
    }
    public void SetStateMove(HeroState state)
    {
        _heroState = state;
        _heroState.OnEnter(this);
    }
    public void ExpKill(int exp, bool kill)//
    {
        _exp = exp;
        if (_exp >= 100) _LV++;
        if (kill == true) _killcount++;
    }
}
public class HeroState
{
    protected Hero _hero;
    Monster _monster;

    public virtual void OnEnter(Hero hero)
    {
        _hero = hero;
    }
    public virtual void HeroDieState()
    {
        
    }

    public virtual void NowState()
    {

    }
    public void HittedColer()
    {
        if (_hero._hit == true)
        {
            _hero._hittimer += Time.deltaTime;
            _hero._render.material.color = Color.red;
            if (_hero._hittimer > 0.5f)
            {
                _hero._render.material.color = _hero.heroColor;
                _hero._hittimer = 0f;
                _hero._hit = false;
            }
        }
    }

}
public class HeroMove : HeroState
{
    public override void OnEnter(Hero hero)
    {
        base.OnEnter(hero);
    }
    public override void NowState()
    {
        if (Input.GetMouseButtonDown(1)) Debug.Log("move");
        float vX = Input.GetAxisRaw("Horizontal");//0=>1D==     -1,1,0���� ��ӵ���
        float vZ = Input.GetAxisRaw("Vertical");//GetAxis 0=0.1=0.2=0.3===1
        _hero._ani.SetFloat("AxisX", vX * _hero._speed);
        _hero._ani.SetFloat("AxisZ", vZ * _hero._speed);
        float vY = _hero.GetComponent<Rigidbody>().velocity.y; //velocity == Rigidbody �ӵ�
        Vector3 v3 = new Vector3(vX, 0, vZ).normalized;
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        _hero.GetComponent<Rigidbody>().velocity = vYz;
        if (Input.GetButton("Horizontal") && vX != 0)
        {
            _hero.transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
        if (Input.GetButton("Vertical") && vZ != 0)
        {
            _hero.transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            _hero.SetStateMove(new HittedState());
        }
    }
}
public class HittedState : HeroState
{
    Define.Monster _mStat;
    Define.MonsterType _mType;
    public void MonsterInfo(Monster monster)
    {
        _mType = monster._monType;
        _mStat = monster._monStat;
    }
    public override void OnEnter(Hero hero)
    {
        base.OnEnter(hero);
    }
    public override void NowState()
    {
        if (_hero._hit == false)  //���ݹ޾�����
        {
            _hero._hp -= (int)_mStat.power; // ���� hpŸ���� float
            _hero._hit = true;
            Debug.Log(_hero._hp);
            _hero.SetStateMove(new HeroMove());
        }
        if (_hero._hp <= 0)
        {
            _hero.fors = _hero.gameObject.transform.position;
            _hero.SetStateMove(new DieState());
        }
    }
}
public class DieState : HeroState
{
    
    public override void OnEnter(Hero hero)
    {
        base.OnEnter(hero);
    }
    public override void NowState()
    {
        _hero._ani.SetInteger("HeroMove", (int)EHeroMove.die);
        _hero.gameObject.transform.position = _hero.fors;
        _hero.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _hero.SetStateMove(new Scenechange());
    }
    public class Scenechange : HeroState
    {
        public override void OnEnter(Hero hero)
        {
            base.OnEnter(hero);
        }
        public override void NowState()
        {
            PlayerPrefs.SetFloat("_lifetime", _hero._lifetimer);//�� ��ȯ�� == 1�������Ͽ� ������ ������ �ı��
            PlayerPrefs.SetInt("_totalDMG", _hero._totalDMG);

            // �Ŵ����� ������ ����
            PlayerPrefs.SetInt("_LV", _hero._LV);
            PlayerPrefs.SetInt("_killcount", _hero._killcount);
            _hero._dietimer += Time.deltaTime;
            if (_hero._dietimer >= 1f) SceneManager.LoadScene("LastScene");
        }
    }
}