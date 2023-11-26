using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float attackRange = 1.0f;
    public Transform target;
    public int maxHealth = 100;
    private int currentHealth;
    
    private Enum_MonsterState currentState = Enum_MonsterState.Idle;

    public void Init()
    {
        //TODO Spec 참조
        currentHealth = 100;
        StartCoroutine(StateMachine());
    }
    
    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case Enum_MonsterState.Idle:
                    CheckMove();
                    break;

                case Enum_MonsterState.Moving:
                    MoveTowardsTarget();
                    break;

                case Enum_MonsterState.Attacking:
                    yield return Attack();
                    break;
            }

            yield return null;
        }
    }

    void CheckMove()
    {
        if (target != null)
        {
            ChangeState(Enum_MonsterState.Moving);
        }
    }

    void MoveTowardsTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            ChangeState(Enum_MonsterState.Attacking);
        }
    }

    void CheckAttackRange()
    {
        if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            ChangeState(Enum_MonsterState.Attacking);
        }
    }

    IEnumerator Attack()
    {
        yield return null;
    }

    public void ChangeState(Enum_MonsterState newState)
    {
        currentState = newState;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        ChangeState(Enum_MonsterState.Moving);
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        MonsterPool.Instance.ReturnObject(gameObject);
        currentHealth = maxHealth; // 체력 초기화
        StopCoroutine(StateMachine());
    }
}