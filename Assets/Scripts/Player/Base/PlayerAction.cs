using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAction : MonoBehaviour
{
    private PlayerAnimation _animation = null;
    protected PlayerAnimation Animator => _animation ??= GetComponent<PlayerAnimation>();

    private PlayerInputController _inputController = null;
    protected PlayerInputController InputController => _inputController ??= GetComponent<PlayerInputController>();
}
