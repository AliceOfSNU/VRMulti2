using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NormalMonster : MonoBehaviour
{
    public NormalMonsterData data;
    NavMeshAgent agent;
    Animator ani;

    [SerializeField] Transform target;
    private void Start()
    {
        ani = GetComponent<Animator>();   
        target = GameObject.FindGameObjectWithTag("Target").transform;
        agent = GetComponent<NavMeshAgent>();
        ChaseToTarget();
    }

    void ChaseToTarget()
    {
        agent.SetDestination(target.position);
        ani.SetFloat("Move", 1f);
    }
    IEnumerator MoveToTarget()
    {
        yield return null;
    }


   
}
