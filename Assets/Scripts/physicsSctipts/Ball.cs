using UnityEngine;

public class Ball : MonoBehaviour, IChangeDirection
{
    [SerializeField] private float Speed;
    private Vector3 _direction;

    public void SetSpeed(float newValue)
    {
        Speed = newValue;
    }

    public void ChangeDirection(Vector3 HitNormal)
    {
        _direction = Vector3.Reflect(_direction, HitNormal);
    }

    private void Start()
    {
        GetRandomDirection();
    }

    private void FixedUpdate()
    {
        transform.position += _direction * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        ChangeDirection(normal);
    }

    private void GetRandomDirection() 
    {
        float angle = Random.Range(0, 360);
        angle *= Mathf.Deg2Rad;
        _direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
    }
}
