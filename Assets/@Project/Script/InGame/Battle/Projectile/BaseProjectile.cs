using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseProjectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public TrailRenderer Renderer;
    // public ParticleSystem ShotParticle;
    // public ParticleSystem HitParticle;
    public GameObject ProjectileModel;
    public Collider2D ProjectileCollider;

    public float hitVFXDelay;
    
    protected Transform StartPosition;
    protected Vector3 StartPositionOffset;
    
    protected SpecProjectile _spec;
    protected Vector2 _direction;
    
    private Coroutine _moveCoroutine;
    private Coroutine _rotateCoroutine;
    private WaitForSeconds _waitForSeconds;
    private WaitForSeconds _hitWaitForSeconds;
    

    private Action _onTargetHit;
    
    public virtual void Initialize(int fieldID)
    {
        //_spec = SpecDataManager.Instance.SpecProjectileData[fieldID];
        _spec = new SpecProjectile(0,1,1,Enum_ProjectileType.Normal);
    }

    public virtual BaseProjectile SetDir(Vector3 direction)
    {
        _direction = direction;
        return this;
    }

    public virtual BaseProjectile SetPos(Vector3 position)
    {
        transform.position = position;
        return this;
    }
    
    public virtual BaseProjectile SetAction(Action action)
    {
        _onTargetHit = action;
        return this;
    }

    #region Attack

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            var monster = other.GetComponent<Monster>();
            
            OnEnemyCollision(monster);
        }
    }
    
    protected virtual void OnEnemyCollision(Monster target)
    {
        if (target != null && !target.isAlive)
        {
            var damage = BattleCharacter.Instance.GetDamage();
            damage.Value *= (1 + _spec.damage);
            target.TakeDamage(damage);
            
            StartCoroutine(HitEffect());
        }
    }
    
    private IEnumerator HitEffect()
    {
        //HitParticle.gameObject.SetActive(true);

        _hitWaitForSeconds ??= new WaitForSeconds(hitVFXDelay);
        
        yield return _hitWaitForSeconds;

        if (_spec.ProjectileType != Enum_ProjectileType.Penetration)
        {
            Hide();
        }
    }
    
    #endregion

    
    public virtual void Shot()
    {
        if (StartPosition != null)
        {
            transform.position = StartPosition.position + StartPositionOffset;
        }
        
        // 오브젝트 초기화
        gameObject.SetActive(true);
        ProjectileModel.SetActive(true);

        if (ProjectileCollider)
        {
            ProjectileCollider.enabled = true;
        }
        
        // 이펙트 초기화
        if (Renderer != null)
        {
            Renderer.Clear();
        }

        StopAllCoroutines();
        _moveCoroutine = StartCoroutine(ProjectileMovement());
        StartCoroutine(HideCoroutine());
    }

    #region Move

    protected virtual IEnumerator ProjectileMovement()
    {
        transform.position = StartPositionOffset;
        
        while (true)
        {
            transform.Translate(_direction*_spec.speed);
            yield break;
        }
    }
    
    #endregion

    #region Hide

    public virtual void Hide(bool force = false)
    {
        gameObject.SetActive(false);

        StartPosition = null;
        StartPositionOffset = Vector3.zero;
        ProjectilePool.Instance.ReturnProjectile(this);
    }

    protected IEnumerator HideCoroutine()
    {
        var delay = GetHideDelay();
        
        _waitForSeconds ??= new WaitForSeconds(delay);
        yield return _waitForSeconds;
        
        Hide();
    }
    
    protected virtual float GetHideDelay()
    {
        return 0;
    }

    #endregion
}