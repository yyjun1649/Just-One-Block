using System;
using System.Collections;
using UnityEngine;

public enum Enum_ProjectileType
{
    
}

public abstract class BaseProjectile : MonoBehaviour
{
    public Enum_ProjectileType Type;
    public TrailRenderer Renderer;
    public ParticleSystem Particle;
    public GameObject ProjectileModel;
    public Collider2D ProjectileCollider;
    public bool HideOnCollision = true;
    public bool StopOnCollision = true;

    public string TargetTag = string.Empty;

    protected float Speed;
    protected float Duration;

    protected Transform StartPosition;
    protected Vector3 StartPositionOffset;
    protected Vector3 Direction;
    protected float Distance;
    protected float RotateDelay;
    protected float RotateDuration;
    protected Quaternion StartRotation;
    protected Quaternion EndRotation;
    protected Monster ShootTarget;
    protected Action<Monster> OnFinish;

    private Coroutine _moveCoroutine;
    private Coroutine _rotateCoroutine;
    private WaitForSeconds _waitForSeconds;

    private bool UseRotate;

    public virtual void Shot(Action<Monster> onFinish)
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

        SetFinishAction(onFinish);
        
        StopAllCoroutines();
        _moveCoroutine = StartCoroutine(ProjectileMovement());

        if (UseRotate)
        {
            _rotateCoroutine = StartCoroutine(ProjectileRotate());
            UseRotate = false;
        }
    }

    protected abstract IEnumerator ProjectileMovement();

    protected virtual IEnumerator ProjectileRotate()
    {
        transform.rotation = StartRotation;
        
        yield return new WaitForSeconds(RotateDelay);

        var rotateTimer = 0f;
        
        while (rotateTimer < RotateDuration)
        {
            rotateTimer += Time.deltaTime;

            transform.rotation = Quaternion.Lerp(StartRotation, EndRotation, rotateTimer / RotateDuration);

            yield return null;
        }
    }

    public BaseProjectile SetFinishAction(Action<Monster> onFinish)
    {
        OnFinish = onFinish;
        return this;
    }

    public BaseProjectile SetStartPosition(Transform position)
    {
        StartPosition = position;
        return this;
    }
    
    public BaseProjectile SetSpawnPosition(Vector3 position)
    {
        transform.position = position;
        return this;
    }
    
    public BaseProjectile SetShootTarget(Monster target)
    {
        ShootTarget = target;
        return this;
    }
    
    public BaseProjectile SetDirection(Vector3 direction)
    {
        Direction = direction;
        transform.rotation = Quaternion.identity;;
        transform.right = Direction;
        return this;
    }

    public BaseProjectile SetSpeed(float speed)
    {
        Speed = speed;
        return this;
    }

    public BaseProjectile SetDuration(float duration)
    {
        Duration = duration;
        return this;
    }

    public BaseProjectile SetDistance(float distance)
    {
        Distance = distance;
        return this;
    }

    public BaseProjectile SetScale(float scale)
    {
        transform.localScale = Vector3.one * scale;
        return this;
    }

    public BaseProjectile SetScale(Vector3 scale)
    {
        transform.localScale = scale;
        return this;
    }

    public BaseProjectile SetRotate(float delay, float speed, Quaternion startRotation, Quaternion endRotation)
    {
        UseRotate = true;
        RotateDelay = delay;
        RotateDuration = speed;
        StartRotation = startRotation;
        EndRotation = endRotation;
        return this;
    }

    public virtual void Hide(bool force = false)
    {
        gameObject.SetActive(false);

        StartPosition = null;
        StartPositionOffset = Vector3.zero;
        StartPositionOffset = Vector3.zero;
        StartPositionOffset = Vector3.zero;
        ShootTarget = null;
        OnFinish = null;
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

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(TargetTag))
        {
            return;
        }

        var target = col.GetComponent<Monster>();
        OnEnemyCollision(target);
    }

    protected virtual void OnEnemyCollision(Monster target)
    {
        if (target != null && target.isAlive)
        {
            OnFinish?.Invoke(target);

            if (StopOnCollision)
            {
                ProjectileCollider.enabled = false;
                ProjectileModel.SetActive(false);
                
                if (_moveCoroutine != null)
                {
                    StopCoroutine(_moveCoroutine);
                }
            }
            
            if (HideOnCollision)
            {
                Hide();
            }
        }
    }

    public void MoveStartPosition(Vector3 offset)
    {
        StartPositionOffset = offset;
    }
}