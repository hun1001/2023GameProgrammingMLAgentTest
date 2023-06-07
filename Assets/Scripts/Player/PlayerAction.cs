using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Animator _animator = null;
    protected Animator Animator => _animator ??= transform.GetChild(0).GetComponent<Animator>();

    private PlayerInputController _inputController = null;
    protected PlayerInputController InputController => _inputController ??= GetComponent<PlayerInputController>();
}
