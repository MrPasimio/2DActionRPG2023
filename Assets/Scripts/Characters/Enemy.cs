using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
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

    [SerializeField] private GameObject target;

    private float lastAttackTime;
    private float targetDistance;

    private void Start()
    {
        //L11
        target = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        targetDistance = Vector2.Distance(transform.position, target.transform.position);

        switch(curState)
        {
            case State.Idle: 
                IdleUpdate();
                break;
            case State.Chase:
                ChaseUpdate();
                break;
            case State.Attack:
                AttackUpdate();
                break;


        }
    }

    void ChangeState(State newState)
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
        //L11 if Enemy is close enough to attack, start attacking
        // if Enemy is to far to chase, start idling
        if(inAttackRange())
        {
            ChangeState(State.Attack);
        }
        else if (targetDistance > chaseDistance)
        {
            ChangeState(State.Idle);
        }

        //move toward the player
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    void AttackUpdate()
    {

    }

    bool inAttackRange()
    {
        return targetDistance <= attackDistance;
    }
}
