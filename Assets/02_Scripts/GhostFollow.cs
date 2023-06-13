using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : MonoBehaviour
{
    private NavMeshAgent Ghost;

    public Transform PlayerTarget;
    // Start is called before the first frame update
    void Start()
    {
        Ghost = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ghost.SetDestination(PlayerTarget.position);
    }
}
