using System.Collections;
using UnityEngine;

public class WhipLaunch : Weapon
{
    [SerializeField] private float _whipLength = 1.75f;

    private PlayerMovement _player;

    protected override void Start()
    {
        base.Start();
        _player = GetComponentInParent<PlayerMovement>();
    }

    protected override IEnumerator AttackProcess()
    {
        Vector3 playerDirection = _player.GetLastMovedVector().normalized;

        Vector3 horizontalDirection = new Vector3(playerDirection.x, 0f, 0f).normalized;

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S) ||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            horizontalDirection = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalDirection = Vector3.left;
        }

        Vector3 whipPosition = transform.position + horizontalDirection * _whipLength;
        Quaternion whipRotation = Quaternion.identity;

        if (horizontalDirection.x > 0)
        {
            whipRotation = Quaternion.Euler(0, -180, 0);
        }

        Damager newWhip = Instantiate(projectilePrefab, whipPosition, whipRotation);
        newWhip.transform.SetParent(transform);
       FireProjectile();
        yield return new WaitForSeconds(waitTime);

        Destroy(newWhip.gameObject);
    }
}



















