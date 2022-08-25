using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChaser : MonoBehaviour
{
    public enum ChaserStatus { Chase, Stun, Rage, HyperRage}
    public int nowStatus = (int)ChaserStatus.Chase;
    public int RageStartKeyCount = 2;
    public float moveSpeed = 3f;
    private NavMeshAgent navmeshagent;
    private Animator animator;
    private bool _isAttack;
    
    [SerializeField] private Transform PlayerTransform;
    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
       navmeshagent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttack == false) Chase();
        if(GameManager.Instance.goldKeyCount >= RageStartKeyCount)
        {
            nowStatus = (int)ChaserStatus.Rage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        navmeshagent.speed = 0f;
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Chase Player", false);
            Attack();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        navmeshagent.speed = moveSpeed;
        animator.SetTrigger("Attack");
        _isAttack = false;
    }


    void Chase()
    {

            navmeshagent.destination = PlayerTransform.position;
            animator.SetBool("Chase Player",true);
    }

    void Stun()
    {
        navmeshagent.speed = 0f;
    }

    void Rage()
    {
        moveSpeed = 4f;
    }

    void HyperRage()
    {

    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        _isAttack = true;
    }

}