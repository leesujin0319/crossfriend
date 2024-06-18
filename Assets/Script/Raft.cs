using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float RangeDestory = 12f;

    void Start()
    {
        
    }

    void Update()
    {
        float movex = moveSpeed * Time.deltaTime;
        this.transform.Translate(movex, 0, 0);

        if (this.transform.localPosition.x >= RangeDestory)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
