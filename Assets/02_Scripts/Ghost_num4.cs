using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_num4 : MonoBehaviour
{
    public string targetTag = "Player";
    public Animator animator;
    public string triggerParameter = "PlayerIn_Range";
    public bool OneTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (OneTrigger == false)
        {
            if (other.CompareTag(targetTag))
            {
                animator.SetTrigger(triggerParameter);
                OneTrigger = true;
            }
        }
      
    }
}
