using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothing = 5f;
    Vector3 m_offsetVal;

    void Start()
    {
        m_offsetVal = transform.position - target.position;
    }

 
    void Update()
    {
        Vector3 cameraPos = target.position + m_offsetVal;

        transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing * Time.deltaTime);
    }
}
