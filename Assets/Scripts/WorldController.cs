using System;
using Setups;
using Zenject;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    [Inject] private GameSettings _gameSettings;

    private float _maxAngle;

    private void OnEnable()
    {
        _signalBus.Subscribe<InputSignal>(RotateWorld);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<InputSignal>(RotateWorld);
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void RotateWorld(InputSignal inputSignal)
    {
        switch (inputSignal.CurrentInput)
        {
            case PlayerInput.NoInput:
                _maxAngle = default;
                break;
            case PlayerInput.Left:
                _maxAngle = -_gameSettings.minMaxAngle;
                break;
            case PlayerInput.Right:
                _maxAngle = _gameSettings.minMaxAngle;
                break;
        }

        transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(0, _maxAngle, inputSignal.Percentage), 0);
    }
}