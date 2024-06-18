using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GrassSpawn : MonoBehaviour
{
    public List<Transform> spawns = new List<Transform>();
    public int startSpawn = -12;
    public int endSpawn = 12;

    public int spawnCreateRandom = 50;

    private void Start()
    {
        GeneratorEnv();
    }
    private void GeneratorRoundBlock()
    {
        int randomindex = 0;
        GameObject treeClone = null;
        Vector3 offsetPos = Vector3.zero;

        for (int i = startSpawn; i < startSpawn; i++)
        {
            if(i < -5 || i > 5)
            {
                randomindex = Random.Range(0, spawns.Count);
                treeClone = GameObject.Instantiate(spawns[randomindex].gameObject);
                treeClone.SetActive(true);
                offsetPos.Set(i, 1f, 0f);


                treeClone.transform.SetParent(this.transform);
                treeClone.transform.localPosition = offsetPos;

            }
        }

    }

    private void GeneratorBackBlock()
    {
        int randomindex = 0;
        GameObject treeClone = null;
        Vector3 offsetPos = Vector3.zero;

        for (int i = startSpawn; i < startSpawn; i++)
        {
                randomindex = Random.Range(0, spawns.Count);
                treeClone = GameObject.Instantiate(spawns[randomindex].gameObject);
                treeClone.SetActive(true);
                offsetPos.Set(i, 1f, 0f);


                treeClone.transform.SetParent(this.transform);
                treeClone.transform.localPosition = offsetPos;

        }
    }

    private void GeneratorTree()
    {
        int randomindex = 0;
        int randomval = 0;
        GameObject treeClone = null;
        Vector3 offsetPos = Vector3.zero;

        for (int i = startSpawn; i < startSpawn; i++)
        {
            randomval = Random.Range(0, 100);
            if (randomval < spawnCreateRandom)
            {
                randomindex = Random.Range(0, spawns.Count);
                treeClone = GameObject.Instantiate(spawns[randomindex].gameObject);
                treeClone.SetActive(true);
                offsetPos.Set(i, 1f, 0f);


                treeClone.transform.SetParent(this.transform);
                treeClone.transform.localPosition = offsetPos;
            }

        }
    }


    private void GeneratorEnv()
    {
        if(this.transform.position.z <= -4)
        {
            GeneratorBackBlock();
        }
        else if(this.transform.position.x <= 0)
        {
            GeneratorRoundBlock();
        }
        else
        {
            GeneratorTree();
        }
    }
}
