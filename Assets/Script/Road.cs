using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Car cloneTarget = null;
    public Transform position = null;
    public int generatePersent = 50;

    public float delay = 1f;
    // 얼마에 한번씩 재생 
    protected float nextToClone = 0f;
    void Start()
    {
        
    }


    void Update()
    {
        float currSec = Time.time;  
        if(nextToClone < currSec)
        {
            int randomval = Random.Range(0, 100);
            if(randomval < generatePersent)
            {
                CloneCar();
            }
          
            nextToClone = currSec + delay;
        }
    }

    void CloneCar()
    {
        Transform clonePos = position;
        Vector3 offsetPos = clonePos.position;
        offsetPos.y = 1f;

        GameObject cloneObj = GameObject.Instantiate(cloneTarget.gameObject, offsetPos, position.rotation, this.transform);
        cloneObj.SetActive(true);
    }
}
