using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _playerInput.Player.Touch.started += ctx => StartTouchPrimary();
        _playerInput.Player.Touch.canceled += ctx => EndTouchPrimary();
    }

    private void StartTouchPrimary()
    {
        EventBus.RaiseEvent<ITouchHandler>(it => it.StartTouch());
    }
    private void EndTouchPrimary()
    {
        EventBus.RaiseEvent<ITouchHandler>(it => it.EndTouch());
    }
}
