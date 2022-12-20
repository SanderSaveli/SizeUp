using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void StartTouch();
    public event StartTouch OnStartTouch;

    public delegate void EndTouch();
    public event StartTouch OnEndTouch;

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
        _playerInput.Touch.PrimaryContact.started += ctx => StartTouchPrimary();
        _playerInput.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary();
    }

    private void StartTouchPrimary()
    {
        if (OnStartTouch != null)
            OnStartTouch();
    }
    private void EndTouchPrimary()
    {
        if (OnEndTouch != null)
            OnEndTouch();
    }
}
