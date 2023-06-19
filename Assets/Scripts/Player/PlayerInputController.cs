using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;

    private Action<float, float> _onArrowInput = null;
    public Action<float, float> OnArrowInput
    {
        get => _onArrowInput;
        set => _onArrowInput = value;
    }

    private Action _onArrowInputRelease = null;
    public Action OnArrowInputRelease
    {
        get => _onArrowInputRelease;
        set => _onArrowInputRelease = value;
    }

    private Action _onAttackInput = null;
    public Action OnAttackInput
    {
        get => _onAttackInput;
        set => _onAttackInput = value;
    }

    private Action<Vector3> _onMousePositionInput = null;
    public Action<Vector3> OnMousePositionInput
    {
        get => _onMousePositionInput;
        set => _onMousePositionInput = value;
    }

    private bool _isUserInputEnabled = true;

    public void DisableUserInput()
    {
        _isUserInputEnabled = false;
    }

    private void Update()
    {
        if (!_isUserInputEnabled)
        {
            return;
        }

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

        _onMousePositionInput?.Invoke(Input.mousePosition);
    }
}
