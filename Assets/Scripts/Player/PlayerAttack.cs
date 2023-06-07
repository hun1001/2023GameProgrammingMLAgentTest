using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAction
{
    private void Awake()
    {
        InputController.OnAttackInput = Attack;
    }

    private void Attack()
    {
        Animator.SetTrigger("Trigger");
    }
}
