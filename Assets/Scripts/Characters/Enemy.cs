using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//L13 Made the class abstract
public abstract class Enemy : Character
{
   public enum State
    {
        Idle,
        Chase,
        Attack
    }

    //L13 changed variables from private to protected
    protected State curState;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float chaseDistance;
    //L13 Removed
    //[SerializeField] private float attackDistance;

    [SerializeField] protected GameObject target;

    protected float lastAttackTime;
    protected float targetDistance;

    [Header("Components")]
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        //L11
        target = FindObjectOfType<Player>().gameObject;
    }

    protected virtual void Update()
    {
        targetDistance = Vector2.Distance(transform.position, target.transform.position);
        spriteRenderer.flipX = GetTargetDirection().x < 0;



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
        if(InAttackRange())
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
        //L12

        if(targetDistance > chaseDistance)
        {
            ChangeState(State.Idle);
        }else if (!InAttackRange())
        {
            ChangeState(State.Chase);
        }

        if(CanAttack())
        {
            lastAttackTime = Time.time;
            AttackTarget();
        }
    }

    //L12
    protected virtual bool CanAttack()
    {
        return false;
    }

    protected virtual void AttackTarget()
    {

    }

    protected virtual bool InAttackRange()
    {
        //L13 Removed
        //return targetDistance <= attackDistance;
        return false;
    }

    protected Vector2 GetTargetDirection()
    {
        return (target.transform.position - transform.position).normalized;
    }

    public override void Die()
    {
        DropItems();
        Destroy(gameObject);
    }

    protected void DropItems()
    {

    }
}
