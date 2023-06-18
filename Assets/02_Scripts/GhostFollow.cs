using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : Ghost
{
    private NavMeshAgent Ghost;
    
   
    public Transform PlayerTarget;

    public float LifeTimer = 40f;
    public GameObject Ghost_obj;

    override public void Update()
    {
      
        if (Spawn == false)
        {
            Ghost_obj.gameObject.SetActive(false);
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0f)
            {
                Debug.Log("Ghost_num3 Spawn");
                SpawnTimer = 170f;
                Spawn = true;
            }
        }
        else if (Spawn == true)
        {
            FollowPlayer();
            Ghost_obj.gameObject.SetActive(true);

            LifeTimer -= Time.deltaTime;

            if (LifeTimer <= 0f)
            {
                Debug.Log("Ghost_num3 Spawn False");
                LifeTimer = 40f;
                Spawn = false;
            }
            GhostAct();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Ghost = GetComponent<NavMeshAgent>();
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }



    override public void Ghostact0()
    {
        Debug.Log("Ghost_act0");
    }
    override public void Ghostact1()
    {
        Debug.Log("Ghost_act1");
    }
    // Update is called once per frame
    private void FollowPlayer()
    {
        Ghost.SetDestination(PlayerTarget.position);
    }
}
