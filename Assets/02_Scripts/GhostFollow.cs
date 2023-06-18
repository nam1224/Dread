using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : Ghost
{
    private NavMeshAgent Ghost;
    
   
    public Transform PlayerTarget;

    public float LifeTimer = 40f;
    public GameObject Ghost_Object;
    // Start is called before the first frame update
    void Start()
    {
        Ghost = GetComponent<NavMeshAgent>();
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void Update()
    {
        FollowPlayer();
        LifeTimer -= Time.deltaTime;

        if (LifeTimer <= 0f)
        {
         Debug.Log("Ghost_num3 Spawn False");
         Destroy(Ghost_Object,0.5f);
        }

    
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
