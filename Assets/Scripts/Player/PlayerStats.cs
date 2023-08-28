using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private Image _healthBar;
    [SerializeField] protected float moveSpeed;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _regeneration = 1;
    [SerializeField] private float _might = 1;
    [SerializeField] private float _speedReaction = 1;
    [SerializeField] private float _projectileSpeed = 1;

    [SerializeField] private float _health;

    private bool _isInvulnerable = false;
    private float _invulnerabilityTimer = 0f;
    private const float _invulnerabilityDuration = 0.1f;

    [SerializeField] private AudioSource _playerHurt;

    [SerializeField] private UpgradeManager _upgradeManager;

    public float MoveSpeed => moveSpeed;
    public float SpeedReaction => _speedReaction;
    public float ProjectileSpeed => _projectileSpeed;
    public float Might => _might;
    public float Health => _health;
    public bool IsDead => Health <= 0;




    private void Awake()
    {
        _health = _maxHealth;
    }
    private void Update()
    {
        RegenerateHealth();
        UpdateHealthBar();
        if (_isInvulnerable)
        {
            _invulnerabilityTimer -= Time.deltaTime;
            if (_invulnerabilityTimer <= 0)
            {
                _isInvulnerable = false;
            }
        }
    }
    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = _health / _maxHealth;
    }

    private void RegenerateHealth()
    {
        if (_health < _maxHealth)
        {
            _health += _regeneration * Time.deltaTime;
            _health = Mathf.Clamp(Health, -1, _maxHealth);
        }

    }

    public void TakeDamage(float damage)
    {
        if (!_isInvulnerable)
        {
            _health -= damage;
            _health = Mathf.Clamp(Health, -1, _maxHealth);
            UpdateHealthBar();

            _isInvulnerable = true;
            _invulnerabilityTimer = _invulnerabilityDuration;
            _playerHurt.Stop();
            _playerHurt.Play();
        }

    }
    public void IncreaseMaxHealth(float multiplayer)
    {
        _maxHealth *= multiplayer;
        _health = Mathf.Min(Health, _maxHealth);
        UpdateHealthBar();
    }
    public void RestoreHealth(float amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        UpdateHealthBar();
    }
    public float IncreaseMoveSpeed(float multiplayer)
    {
        return moveSpeed *= multiplayer;
    }
    public void IncreaseMight(float multiplayer)
    {
        _might *= multiplayer;
    }
    public void IncreaseRegenerate(float multiplayer)
    {
        _regeneration += multiplayer;
    }
    public void IncreaseProjectileSpeed(float multiplayer)
    {
        _projectileSpeed *= multiplayer;

    }
    public void IncreaseSpeedReaction(float multiplayer)
    {
        _speedReaction *= multiplayer;
    }


}
