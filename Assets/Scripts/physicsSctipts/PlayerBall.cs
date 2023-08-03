using System.Collections;
using UnityEngine;
using ViewElements;

public class PlayerBall : Ball, ITouchHandler
{
    [SerializeField] private float SizeIncreasePerSecondInPercent;
    [SerializeField] private float SizeDecreasePerSecondInPercent;
    private float _normalSize;
    private bool _isRise;

    protected override void OnEnable()
    {
        base.OnEnable();
        EventBus.Subscribe(this);
        _normalSize = transform.localScale.x;
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection(collision.contacts[0].normal);
        if(_isRise && collision.gameObject.GetComponent<EnemyBall>() != null) 
        {
            Death();
        }
    }

    void ITouchHandler.StartTouch()
    {
        _isRise = true;
        StopCoroutine(BackToNormalSize());
        StartCoroutine(Increas());
    }

    void ITouchHandler.EndTouch()
    {
        _isRise = false;
        StopAllCoroutines();
        StartCoroutine(BackToNormalSize());
    }

    private IEnumerator Increas()
    {
        while (_isRise)
        {
            ChangeSize();
            yield return null;
        }
    }

    private IEnumerator BackToNormalSize() 
    { 
        while(transform.localScale.x > _normalSize && !_isRise) 
        {
            transform.localScale *= 1 - SizeDecreasePerSecondInPercent * Time.deltaTime / 100;
            yield return null;
        }
        if(!_isRise)
            transform.localScale = new Vector3(_normalSize, _normalSize, _normalSize);
    }

    private void ChangeSize()
    {
        float ScaleCoefficent = SizeIncreasePerSecondInPercent * Time.deltaTime / 100 + 1;
        transform.localScale *= ScaleCoefficent;
    }

    private void Death() 
    {
        EventBus.RaiseEvent<IGameEndHandler>(it => it.GameEnd());
        Destroy(gameObject);
    }
}
