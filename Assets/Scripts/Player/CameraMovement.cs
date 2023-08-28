using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 newPosition = _target.position + _offset;
            transform.position = newPosition;
        }
    }
}
