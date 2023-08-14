using UnityEngine;

namespace Gameplay 
{
    public class Ball : MonoBehaviour, IChangeDirection
    {
        [SerializeField] private float Speed;
        private Vector3 _direction;

        protected virtual void OnEnable()
        {
            GetRandomDirection();
        }

        protected virtual void FixedUpdate()
        {
            transform.position += _direction * Speed * Time.deltaTime;
        }

        public void SetSpeed(float newValue)
        {
            Speed = newValue;
        }

        public void ChangeDirection(Vector3 HitNormal)
        {
            _direction = Vector3.Reflect(_direction, HitNormal);
            _direction.z = 0;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector3 normal = collision.contacts[0].normal;
            ChangeDirection(normal);
        }

        private void OnCollisionStay2D(Collision2D collision)
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
}
