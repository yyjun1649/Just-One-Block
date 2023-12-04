using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public SpecMonster Spec;
    public Transform target;
    private float currentHealth;
    public bool isAlive = false;
    
    private Enum_MonsterState currentState = Enum_MonsterState.Idle;

    public void Init(int fieldID)
    {
        Spec = SpecDataManager.Instance.SpecMonsterData[fieldID];

        isAlive = true;
        currentHealth = Spec.health;
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
        if (Vector2.Distance(transform.position, target.position) > Spec.attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Spec.speed * Time.deltaTime);
        }
        else
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
    
    public void TakeDamage(Damage damage)
    {
        currentHealth -= damage.Value;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        MonsterPool.Instance.ReturnObject(this);
        currentHealth = 0; // 체력 초기화
        StopCoroutine(StateMachine());
    }
}