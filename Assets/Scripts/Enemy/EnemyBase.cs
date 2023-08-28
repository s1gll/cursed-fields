using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] private float _maxHealth;
    [SerializeField] private AudioSource _enemyHit;

    [SerializeField] protected ExperiencePickup pickup;
    private FlashSpriteEffect _flashSpriteEffect;
    protected Transform target;
    public UnityEvent OnDied;
    public UnityEvent OnTakeDamage;


    public float Health { get; private set; }
    protected virtual void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
        _flashSpriteEffect=GetComponent<FlashSpriteEffect>();
    }

    public bool IsDead => Health <= 0;
    private void Awake()
    {
        Health = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
_enemyHit.pitch=Random.Range(0.9f,1.1f);
 _enemyHit.Stop();
        _enemyHit.Play();
        Health = Mathf.Clamp(Health, 0, _maxHealth);
       _flashSpriteEffect.Flash();
        OnTakeDamage.Invoke();
        if (IsDead)
        {
            OnDead();
        }
        
    }
protected virtual void CheckForFlipping(Vector2 direction)
{
    bool movingLeft = direction.x < 0;
    bool movingRight = direction.x > 0;

    float commonScaleX = Mathf.Abs(transform.localScale.x); 

    if (movingLeft)
    {
        transform.localScale = new Vector3(-commonScaleX, transform.localScale.y);
    }
    else if (movingRight)
    {
        transform.localScale = new Vector3(commonScaleX, transform.localScale.y);
    }
}
  

    protected virtual void OnDead()
    {
    }
}
