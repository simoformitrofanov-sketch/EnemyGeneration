using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Vector3 _direction;
    private bool _hasDirection;

    private void Update()
    {
        if (_hasDirection == false)
            return;

        transform.position += _direction * (_speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
        _hasDirection = true;
    }
}