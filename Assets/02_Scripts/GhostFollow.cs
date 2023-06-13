using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : Ghost
{
    private NavMeshAgent Ghost;

    public Transform PlayerTarget;
    // Start is called before the first frame update
    void Start()
    {
        Ghost = GetComponent<NavMeshAgent>();
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
    void Update()
    {
        Ghost.SetDestination(PlayerTarget.position);
    }
}
