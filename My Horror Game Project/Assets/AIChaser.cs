using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChaser : MonoBehaviour
{
    public enum ChaserStatus { Chase, Stun, Rage, HyperRage}
    public int nowStatus;
    [SerializeField] private Transform PlayerTransform;
                    private NavMeshAgent navmeshagent;
                    private Animator animator;
    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }


    void Chase()
    {
        if(ChaserStatus.Chase == 0 )
        {
            navmeshagent.destination = PlayerTransform.position;
            animator.SetBool("Chase Player",true);
        }
    }

    void Stun()
    {

    }

    void Rage()
    {

    }

    void HyperRage()
    {

    }
}
