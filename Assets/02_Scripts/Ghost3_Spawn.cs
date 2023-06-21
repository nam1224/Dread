using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost3_Spawn : MonoBehaviour
{
    public GameObject Ghost3_Prefab;
    public float SpawnTimer = 170f;
    void Start()
    {
      //  GameObject Ghost;
    }

    // Update is called once per frame
    public void Update()
    {

        SpawnCoolTime();
    }
    
    void SpawnCoolTime()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0f)
        {

            Instantiate(Ghost3_Prefab);
           // Debug.Log("Ghost_num3 Spawn");

            SpawnTimer = 170f;
          
        }
    }
}
