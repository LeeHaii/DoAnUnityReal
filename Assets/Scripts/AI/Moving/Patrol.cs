using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    private Vector3 destination;

    private void Update()
    {
        destination = player.position;
        agent.destination = destination;
        if (!agent.pathPending)
        {
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.ResetTrigger("fly");
                animator.SetTrigger("idle");
            }
        }
        else
        {
            animator.ResetTrigger("idle");
            animator.SetTrigger("fly");
        }
    }
}
