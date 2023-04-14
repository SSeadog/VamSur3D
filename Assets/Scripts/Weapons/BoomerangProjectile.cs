using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    Vector3 _moveVec;
    float _speed;

    float _lifeTime = 5f;
    float _lifeTimer = 0f;

    public void Init(Vector3 moveVec, float speed)
    {
        _moveVec = moveVec;
        _speed = speed;
    }

    void Update()
    {
        _lifeTimer += Time.deltaTime;
        if (_lifeTimer >= _lifeTime )
            Destroy(gameObject);

        Move();
    }

    void Move()
    {
        transform.position += _moveVec * Time.deltaTime * _speed * 10f;
    }

    public void Attack()
    {
        _moveVec = _moveVec * -1f;
    }
}
