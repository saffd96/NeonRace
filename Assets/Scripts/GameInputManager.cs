using Zenject;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInputManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Inject] private SignalBus _signalBus;

    private float _halfWidth;
    private PlayerInput _currentInput;

    private float _currentTimer;
    private float _calculateTimer = 0.25f;

    private float _percentage;

    private void Awake()
    {
        _halfWidth = Screen.width / 2.0f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsTimerExpired()) return;
        
        _percentage = default;
        _currentInput = PlayerInput.NoInput;

        float xPos = eventData.position.x;

        if (xPos < _halfWidth)
        {
            _currentInput = PlayerInput.Left;
            _percentage = (_halfWidth - xPos) / _halfWidth;
        }
        else if (xPos > _halfWidth)
        {
            _currentInput = PlayerInput.Right;
            _percentage = (xPos - _halfWidth) / _halfWidth;
        }
        
        _signalBus.Fire(new InputSignal(_currentInput, _percentage));
        
        _currentTimer = 0;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _currentInput = PlayerInput.NoInput;
    }

    private bool IsTimerExpired()
    {
        _currentTimer += Time.deltaTime;
        return _currentTimer >= _calculateTimer;
    }
}

public enum PlayerInput
{
    NoInput = 0,
    Left = 1,
    Right = 2,
}