using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : character
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    private State curState;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance;

    private GameObject target;

    private float lastAttackTime;
    private float targetDistance;

     void Start()
     {
        target = FindObjectOfType<Player>().gameObject;
     }

     void Update()
     {
        targetDistance = Vector2.Distance(transform.position, target.transform.position);
        
        switch (curState)
        {
            case State.Idle: IdleUpdate(); break;
            case State.Chase: ChaseUpdate(); break;
            case State.Attack: AttackUpdate(); break;
        }
     }
    
    void ChangeState (State newState)
    {
        curState = newState;
    }
    void IdleUpdate()
    {
        if(targetDistance <= chaseDistance)
        {
            ChangeState(State.Chase);
        }
            
    }

    void ChaseUpdate()
    {

    }

    void AttackUpdate()
    {

    }
}
