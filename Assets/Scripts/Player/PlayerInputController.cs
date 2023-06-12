using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;

    private Action<float, float> _onArrowInput = null;
    public Action<float, float> OnArrowInput { set => _onArrowInput = value; }

    private Action _onArrowInputRelease = null;
    public Action OnArrowInputRelease { set => _onArrowInputRelease = value; }

    private Action _onAttackInput = null;
    public Action OnAttackInput { set => _onAttackInput = value; }

    protected virtual void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (_horizontalInput != 0f || _verticalInput != 0f)
        {
            _onArrowInput?.Invoke(_horizontalInput, _verticalInput);
        }
        else
        {
            _onArrowInputRelease?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            _onAttackInput?.Invoke();
        }
    }
}
