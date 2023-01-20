using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(moveX, 0, moveY).normalized;

        transform.Translate(moveVec * Time.deltaTime * _speed);
    }
}
