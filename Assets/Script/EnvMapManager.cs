using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public enum LastRoadType
    {
        Grass = 0,
        Road ,
        Max
    }


    //public GameObject[] envObjectArray;

    public Road DefaultRoad = null;
    public Road WaterRoad = null;   
    public GrassSpawn GrassSpawn = null;

    public Transform parentTransform = null;

    public int minPosZ = -20;
    public int maxPosZ = 20;

    public int frontOffsetPosZ = 20;
    public int backOffsetPosZ = 10;

    private List<Transform> mapList = new List<Transform>();    
    private Dictionary<int, Transform> mapDic = new Dictionary<int, Transform>();   
    private LastRoadType lastRoadType = LastRoadType.Max;
    private int LastLinePos = 0;
    

    private int lastLine = 0;
    public int deleteLine = 10;
    public int backOffsetLineCount = 30;



    void Start()
    {
       
    }

    public void UpdateForwardBackMove(int p_posz)
    {
        if(mapList.Count <= 0)
        {
            lastRoadType = LastRoadType.Grass;
            lastLine = minPosZ;
            int i = 0;
            // 檬扁 积己
            for(i = minPosZ; i<maxPosZ; i++)
            {
                int offsetval = 0;
                if(i < 0)
                {
                    GeneratorGrassLine(i);
                }
                else
                {

                    if(lastRoadType == LastRoadType.Grass)
                    {
                        int randomVal = Random.Range(0, 2);
                        if(randomVal == 0)
                        {
                            offsetval = GroupWaterLine(i);
                        }
                        else
                        {
                            offsetval = GroupRoadLine(i);
                        }

                        lastRoadType = LastRoadType.Road;

                    }
                    else
                    {
                        offsetval = GroupGrassLine(i);
                        lastRoadType = LastRoadType.Grass;
                    }

                    i += offsetval - 1;

                }
            }

            LastLinePos = i;
        }

        // 货肺 积己
        if(LastLinePos < p_posz + frontOffsetPosZ) 
        {
            int offsetval = 0;
            if (lastRoadType == LastRoadType.Grass)
            {
                int randomVal = Random.Range(0, 2);
                if (randomVal == 0)
                {
                    offsetval = GroupWaterLine(LastLinePos);
                }
                else
                {
                    offsetval = GroupRoadLine(LastLinePos);
                }

                lastRoadType = LastRoadType.Road;

            }
            else
            {
                offsetval = GroupGrassLine(LastLinePos);
                lastRoadType = LastRoadType.Grass;
            }

            LastLinePos += offsetval;
        }

        if(p_posz - backOffsetLineCount > lastLine - deleteLine)
        {
            int count = lastLine + deleteLine;
            for(int i = lastLine; i<count; i++)
            {
                DeleteLine(i);
            }

            lastLine += deleteLine; 
        }

        void DeleteLine(int p_posz)
        {
            if (mapDic.ContainsKey(p_posz))
            {
                Transform transObj = mapDic[p_posz];
                GameObject.Destroy(transform.gameObject);
                mapList.Remove(transObj);
                mapDic.Remove(p_posz);
                
            }
            else
            {

            }
        }
    }

    public void GeneratorGrassLine(int p_posz)
    {
        GameObject cloneObj = GameObject.Instantiate(GrassSpawn.gameObject);
        cloneObj.SetActive(true);
        Vector3 pos = Vector3.zero;

        pos.z = (float)p_posz;
        cloneObj.transform.SetParent(parentTransform);
        cloneObj.transform.position = pos;


        mapList.Add(cloneObj.transform);
        mapDic.Add(p_posz, cloneObj.transform);
    }
    
    public void GeneratorRoadLine(int p_posz)
    {
        GameObject cloneObj = GameObject.Instantiate(DefaultRoad.gameObject);
        cloneObj.SetActive(true);
        Vector3 pos = Vector3.zero;

        pos.z = (float)p_posz;
        cloneObj.transform.SetParent(parentTransform);
        cloneObj.transform.position = pos;

        int randomRot = Random.Range(0, 2);
        if (randomRot == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        mapList.Add(cloneObj.transform);
        mapDic.Add(p_posz, cloneObj.transform);
    }

    public void GeneratorWaterLine(int p_posz)
    {
        GameObject cloneObj = GameObject.Instantiate(WaterRoad.gameObject);
        cloneObj.SetActive(true);
        Vector3 pos = Vector3.zero;

        pos.z = (float)p_posz;
        cloneObj.transform.SetParent(parentTransform);
        cloneObj.transform.position = pos;

        int randomRot = Random.Range(0, 2);
        if (randomRot == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        mapList.Add(cloneObj.transform);
        mapDic.Add(p_posz, cloneObj.transform);
    }

    public int GroupWaterLine(int p_posz)
    {
        int randomCount = Random.Range(1, 4);

        for(int i = 0; i < randomCount; i++)
        {
            GeneratorWaterLine(p_posz + i);
        }

        return randomCount;
    }

    public int GroupGrassLine(int p_posz)
    {
        int randomCount = Random.Range(1, 4);

        for (int i = 0; i < randomCount; i++)
        {
            GeneratorGrassLine(p_posz + i);
        }

        return randomCount;
    }

    public int GroupRoadLine(int p_posz)
    {
        int randomCount = Random.Range(1, 4);

        for (int i = 0; i < randomCount; i++)
        {
            GeneratorRoadLine(p_posz + i);
        }

        return randomCount;
    }
}
