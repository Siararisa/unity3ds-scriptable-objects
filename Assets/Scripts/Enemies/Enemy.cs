using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyData;
    private Animator animator;
    public Transform target;
  
    private float distanceFromTarget = 0;
    //Enemy AI
    //Idle -> Move Towards Target -> In Range? -> Attack

    private IEnumerator Start()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = enemyData.controller;
        // Default animation is idle so we simply wait a few seconds
        yield return new WaitForSeconds(enemyData.idleTime);
        StartCoroutine(MoveToTarget());
        enemyData.PrintEnemyStats();
    }

    private IEnumerator MoveToTarget()
    {
        animator.SetBool("Run", true);
        while(distanceFromTarget > enemyData.attackRange)
        {
            transform.position += Vector3.right * enemyData.movementSpeed * Time.deltaTime;
            yield return null;
        }
        animator.SetBool("Run", false);
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        animator.SetTrigger("Attack");
        //Wait until animation ends
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        animator.SetTrigger("Ability");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        StartCoroutine(Attack());
    }

    void Update()
    {
        // Calculate the distance between ourself and the player
        distanceFromTarget = Vector3.Distance(transform.position,
            target.position);
    }
}
