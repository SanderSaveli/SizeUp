using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector3 _direction;

    public void SetSpeed(float newValue)
    {
        Speed = newValue;
    }

    private void FixedUpdate()
    {
        transform.position += _direction * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection(collision.contacts[0].normal);
    }

    private void ChangeDirection(Vector3 HitNormal)
    {
        _direction = Vector3.Reflect(_direction, HitNormal);
    }
}
