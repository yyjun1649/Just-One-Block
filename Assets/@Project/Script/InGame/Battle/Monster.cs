using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public SpecMonster Spec;
    public Transform target;
    private float currentHealth;
    public bool isAlive = false;
    
    private Enum_MonsterState currentState = Enum_MonsterState.Idle;
    private Damage damage = new Damage();
    public void Init(int fieldID)
    {
        //Spec = SpecDataManager.Instance.SpecMonsterData[fieldID];
        Spec = new SpecMonster(0,0,1,1,1,1,1);
        damage.Value = 1;
        SetTarget(BattleCharacter.Instance.transform);
        isAlive = true;
        currentHealth = Spec.health;
        gameObject.SetActive(true);
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
        BattleCharacter.Instance.TakeDamage(damage);
        yield return Spec.attackSpeed;
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
        gameObject.SetActive(false);
        
        RewardManager.TryConsume(_reward);
    }

    private Reward _reward = new Reward(Enum_RewardType.Blood, 0, 1);
}