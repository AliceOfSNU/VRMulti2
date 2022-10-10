using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NormalMonster : MonoBehaviour
{
    public NormalMonsterData data;
    NavMeshAgent agent;

    [SerializeField] Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    IEnumerator MoveToTarget()
    {
        yield return null;
    }
}
