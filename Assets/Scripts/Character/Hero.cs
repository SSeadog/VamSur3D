using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using Define;
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
   
    HeroState _HeroState;
    Define.Monster _mStat;
    Define.Hero _heroData;
    public Define.Hero _HeroData { get { return _heroData; } set { _heroData = value; } }
    SkinnedMeshRenderer render;
    public SkinnedMeshRenderer _render { get { return render; } set { render = value; } }

    Animator _ani;
    public Animator _HeroAni { get { return _ani; } set { _ani = value; } }

    Color heroColor;
    public Color _heroColor { get { return heroColor; } set { heroColor = value; } }
    Vector3 fors;
    public Vector3 _fors { get { return fors; } set { fors = value; } }
    bool hit = false;   public bool _hit { get { return hit; } set { hit = value; } }
    float _hp = 0f;   public float HeroHP { get { return _hp; } set { _hp = value; } }
    float _attackPower = 0f;
    private void Awake()
    {
        heroDataSet(GenericSingleton<GameManager>.getInstance().HeroType);
        _HeroAni = GetComponentInChildren<Animator>();
        _render = GetComponentInChildren<SkinnedMeshRenderer>();
        _heroColor = _render.material.color;
        Debug.Log(_HeroAni);
        GenericSingleton<GameManager>.getInstance().Player = gameObject;
        Debug.Log(_HeroData );
        HeroHP = _HeroData.hp;
        _attackPower = _HeroData.power;//
    }
   public  void heroDataSet(HeroType inheroType)
    {
        Define.HeroType heroType = inheroType; 
        Define.Hero heroData = GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        _HeroData = heroData;
    }
    void Start()
    {

        Debug.Log(GenericSingleton<GameManager>.getInstance().SurviveTime);
        _HeroState = new HeroMove();
        SetStateMove(new HeroMove());// 상태 저장,실행

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetStateMove(new DieState());
        }
        GenericSingleton<GameManager>.getInstance().SurviveTime += Time.deltaTime;
        _HeroState.NowState();
        _HeroState.HittedColer();
        // 경험치 획득 임시 코드 // 몬스터가 죽었을때 실행하게 몬스터 코드에 있는게 맞음 몬스터 마다 경험치가 다르니
        if (Input.GetKeyDown(KeyCode.E))
            GenericSingleton<GameManager>.getInstance().GetExp(10);
    }

    public void MonsterInfo(Define.Monster monster)
    {
        Debug.Log("MonsterInfo" + (_mStat == null));
        _mStat = monster;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Monster>() != null)
        {
            MonsterInfo(collision.gameObject.GetComponent<Monster>().sendMonsterStat);
            if (_hit == false) StartCoroutine("hittedWait");
        }
    }
    IEnumerator hittedWait()
    {
        _hit = true;
        hitted();
        yield return new WaitForSeconds(0.5f);
        _hit = false;
    }
    public void hitted()
    {
        HeroHP -= _mStat.power;
        Debug.Log(HeroHP);
        if (HeroHP <= 0)
        {
            _fors = gameObject.transform.position;
            SetStateMove(new DieState());
        }
    }
    public void SetStateMove(HeroState state)
    {
        _HeroState = state;
        _HeroState.OnEnter(this);
    }
}
public class HeroState
{
    protected Hero _hero;
   protected float _dieTimer, _hitTimer = 0f;
    public virtual void OnEnter(Hero hero)
    {
        _hero = hero;
        _hero.heroDataSet(GenericSingleton<GameManager>.getInstance().HeroType);
    }
    public virtual void HeroDieState() { }
    public virtual void NowState() { }
    public void HittedColer()
    {
        if (_hero._hit == true)
        {
            _hitTimer += Time.deltaTime;
            _hero._render.material.color = Color.red;
        }
        if (_hero._hit == false)
        {
            _hero._render.material.color = _hero._heroColor;
            _hitTimer = 0f;
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
        float vX = Input.GetAxisRaw("Horizontal");//0=>1D==     -1,1,0값이 계속들어옴
        float vZ = Input.GetAxisRaw("Vertical");//GetAxis 0=0.1=0.2=0.3===1
        _hero._HeroAni.SetFloat("AxisX", vX * _hero._HeroData.moveSpeed);
        _hero._HeroAni.SetFloat("AxisZ", vZ * _hero._HeroData.moveSpeed);
        float vY = _hero.GetComponent<Rigidbody>().velocity.y; //velocity == Rigidbody 속도
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
        _hero._HeroAni.SetInteger("HeroMove", (int)EHeroMove.die);
        _hero.gameObject.transform.position = _hero._fors;
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
            _dieTimer += Time.deltaTime;
            if (_dieTimer >= 1f) SceneManager.LoadScene("LastScene");
        }
    }
}