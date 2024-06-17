using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        float movex = moveSpeed * Time.deltaTime;
        this.transform.Translate(movex, 0, 0);

        if(this.transform.localPosition.x >= 12f )
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
