using UnityEngine;
using EventBusSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private bool _isAcktive;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _isAcktive = true;
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _isAcktive = false;
        _playerInput.Disable();
    }

    private void Start()
    {
        _playerInput.Player.Touch.started += ctx => StartTouchPrimary();
        _playerInput.Player.Touch.canceled += ctx => EndTouchPrimary();
    }

    private void StartTouchPrimary()
    {
        if(_isAcktive)
            EventBus.RaiseEvent<ITouchHandler>(it => it.StartTouch());
    }
    private void EndTouchPrimary()
    {
        if(_isAcktive)
            EventBus.RaiseEvent<ITouchHandler>(it => it.EndTouch());
    }
}
