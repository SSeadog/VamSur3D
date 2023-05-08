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
    [SerializeField] protected SkinnedMeshRenderer _render;
    [SerializeField] protected Animator _ani;
    [SerializeField] GameObject _Hero;
    HeroState _heroState;
    Define.Hero _heroData;
    Define.Monster _mStat;

    //캐릭터 스택은 외부 파일에서 불러옴
   public float _hp = 0f; // todo PlayerHPBarUI 에서 받아서 퍼블릭아니면안됨
    protected float _dieTimer, _hitTimer, _attackPower = 0f;
    protected bool _hit = false;
    protected Color heroColor;
    protected Vector3 fors;

    public float HeroHP { get { return _hp; } }
  
    private void Awake()
    {
        heroDataSet(GenericSingleton<GameManager>.getInstance().heroType);//Managers.Game.heroType== // 로비씬에서 넘겨준 데이터를 활용할 것선택된 타입
        _hp = _heroData.hp;
        _attackPower = _heroData.power;
        Debug.Log(_hp);
    }
    void heroDataSet(HeroType inheroType)
    {
        Define.HeroType heroType = inheroType; 
        Define.Hero heroData = GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        _heroData = heroData;
    }
    void Start()
    {
        Debug.Log(GenericSingleton<GameManager>.getInstance().surviveTime);
        _heroState = new HeroState();
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
        _hp -= _mStat.power;
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            fors = gameObject.transform.position;
            SetStateMove(new DieState());
        }
    }
    public void SetStateMove(HeroState state)
    {
        _heroState = state;
        _heroState.OnEnter(this);
    }
}
public class HeroState :Hero
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
        if (_hit == true)
        {
            _hitTimer += Time.deltaTime;
            _render.material.color = Color.red;
        }
        if (_hit == false)
        {
            _render.material.color = heroColor;
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
        _ani.SetFloat("AxisX", vX * 3);
        _ani.SetFloat("AxisZ", vZ * 3);
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
        _ani.SetInteger("HeroMove", (int)EHeroMove.die);
        _hero.gameObject.transform.position = fors;
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