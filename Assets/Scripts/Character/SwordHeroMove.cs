using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ESwordHeroMove
{
    Idle,
    w,//forward
    a,//left
    s,//back
    d,//right

}
public class SwordHeroMove : MonoBehaviour
{
    [SerializeField] float speed;
    Animator _ani;
    
    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void move()
    {
        Vector3 v3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            v3 += (Vector3.forward).normalized * Time.deltaTime * speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
            Debug.Log("forward");
        }
       if (Input.GetKey(KeyCode.A))
        {
           v3 += (Vector3.left).normalized * Time.deltaTime * speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
             Debug.Log("left");
        }
        if (Input.GetKey(KeyCode.S))
        {
            v3 += (Vector3.back).normalized * Time.deltaTime * speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
            Debug.Log("back");
        }
        if (Input.GetKey(KeyCode.D))
        {
            v3 += (Vector3.right).normalized * Time.deltaTime * speed;
            _ani.SetInteger("SwordHero", (int)ESwordHeroMove.w);
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
}
