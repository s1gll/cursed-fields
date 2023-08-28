using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveInput;

    private float _lastHorizontalVector, _lastVerticalVector;
    private Vector2 _lastMovedVector;

    private Rigidbody2D _theRB;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerStats _playerStats;
   

    private void Start()
    {
        _theRB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerStats = GetComponent<PlayerStats>();
        _lastMovedVector = new Vector2(1f, 0f);
    }

    private void Update()
    {
        ProcessInput();
    }
    private void FixedUpdate()
    {
        ApplyMovement();
    }
    private void ProcessInput()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _moveInput.Normalize();

    }

    private void ApplyMovement()
    {
        _theRB.velocity = _playerStats.MoveSpeed * _moveInput;
        CheckSpriteDirection(_spriteRenderer);

        bool isMoving = _moveInput.magnitude > 0.01;
        _animator.SetBool("Move", isMoving);

        if (_moveInput.x != 0)
        {
            _lastHorizontalVector = _moveInput.x;
            _lastMovedVector = new Vector2(_lastHorizontalVector, 0f);
        }
        if (_moveInput.y != 0)
        {
            _lastVerticalVector = _moveInput.y;
            _lastMovedVector = new Vector2(0f, _lastVerticalVector);
        }
        if (_moveInput.y != 0 && _moveInput.x != 0)
        {
            _lastMovedVector = new Vector2(_lastHorizontalVector, _lastVerticalVector);
        }
    }
    private void CheckSpriteDirection(SpriteRenderer spriteRenderer)
    {
        if (_lastHorizontalVector < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    public Vector2 GetLastMovedVector()
    {
        return _lastMovedVector;
    }

}




