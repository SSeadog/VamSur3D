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

        Vector3 dir = new Vector3(moveX, 0, moveY).normalized;

        if (dir.magnitude > 0.01f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);

            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
        }
    }
}
