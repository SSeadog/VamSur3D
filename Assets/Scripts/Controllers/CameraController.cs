using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject _target;

    [SerializeField] float offsetX = 12f;
    [SerializeField] float offsetY = -8f;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 offset = new Vector3(0, offsetY, offsetX);
        transform.position = _target.transform.position + offset;
        transform.LookAt(_target.transform);
    }
}
