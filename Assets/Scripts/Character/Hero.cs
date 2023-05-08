using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using static Define;
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
    Define.Hero _herodata;
    HeroState _heroState;
    public Color heroColor;
    [SerializeField] public SkinnedMeshRenderer _render;
    [SerializeField] public Animator _ani;
    [SerializeField] GameObject _Hero;
    //캐릭터 스택은 외부 파일에서 불러옴
    public float _dietimer, _hittimer, _hp, _attackpower = 0f;
    public bool _hit = false;

    public Vector3 fors;
    private void Awake()
    {
        heroDataSet(GenericSingleton<GameManager>.getInstance().heroType);//Managers.Game.heroType== // 로비씬에서 넘겨준 데이터를 활용할 것선택된 타입
        _hp = _herodata.hp;
        _attackpower = _herodata.power;
        Debug.Log(_hp);
    }
    void heroDataSet(HeroType inheroType)
    {
        Define.HeroType heroType = inheroType; 
        Define.Hero heroData = GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        _herodata = heroData;
    }
    void Start()
    {
        Debug.Log(GenericSingleton<GameManager>.getInstance().surviveTime);
        _heroState = new HeroMove();
        SetStateMove(new HeroMove());// 상태 저장,실행
        GenericSingleton<GameManager>.getInstance().player = gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetStateMove(new DieState());
        }
        GenericSingleton<GameManager>.getInstance().surviveTime += Time.deltaTime;
        _heroState.NowState();
        _heroState.HittedColer();
        // 경험치 획득 임시 코드 // 몬스터가 죽었을때 실행하게 몬스터 코드에 있는게 맞음 몬스터 마다 경험치가 다르니
        if (Input.GetKeyDown(KeyCode.E))
            GenericSingleton<GameManager>.getInstance().GetExp(10);
    }

    Define.Monster _mStat;
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
    public void hitted()
    {
        _hp -= _mStat.power;
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            fors = gameObject.transform.position;
            SetStateMove(new DieState());
        }
    }
    IEnumerator hittedWait()
    {
        _hit = true;
        hitted();
        yield return new WaitForSeconds(0.5f);
        _hit = false;
    }
    public void SetStateMove(HeroState state)
    {
        _heroState = state;
        _heroState.OnEnter(this);
    }
}
public class HeroState
{
    protected Define.Hero _herodata;
    protected Hero _hero;
    public virtual void OnEnter(Hero hero)
    {
        _hero = hero;
    }
    public virtual void HeroDieState() { }
    public virtual void NowState() { }
    public void HittedColer()
    {
        if (_hero._hit == true)
        {
            _hero._hittimer += Time.deltaTime;
            _hero._render.material.color = Color.red;
        }
        if (_hero._hit == false)
        {
            _hero._render.material.color = _hero.heroColor;
            _hero._hittimer = 0f;
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
        _hero._ani.SetFloat("AxisX", vX * _herodata.moveSpeed);
        _hero._ani.SetFloat("AxisZ", vZ * _herodata.moveSpeed);
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
            _hero._dietimer += Time.deltaTime;
            if (_hero._dietimer >= 1f) SceneManager.LoadScene("LastScene");
        }
    }
}