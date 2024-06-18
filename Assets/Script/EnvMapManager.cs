using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvMapManager : MonoBehaviour
{

    public enum EnvType
    {
        Grass = 0,
        Road,
        Water,
        Max
    }


    //public GameObject[] envObjectArray;

    public Road DefaultRoad = null;
    public Road WaterRoad = null;   
    public GrassSpawn GrassSpawn = null;

    public Transform parentTransform = null;

    public int minPosZ = -20;
    public int maxPosZ = 20;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = minPosZ; i <= maxPosZ; i++)
        {
            CloneRoad(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CloneRoad(int p)
    {
        int randomIndex = Random.Range(0, envObjectArray.Length);
        GameObject cloneObj = GameObject.Instantiate(envObjectArray[randomIndex]);
        cloneObj.SetActive(true);
        Vector3 pos = Vector3.zero;

        pos.z = (float)p;
        cloneObj.transform.SetParent(parentTransform);
        cloneObj.transform.position = pos;

        int randomRot = Random.Range(0, 2);
        if(randomRot == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }


    }   
}
