using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAction
{
    [SerializeField]
    private HitBoxController _hitBoxController = null;

    private bool _isAttacking = false;

    private void Awake()
    {
        InputController.OnAttackInput = Attack;
    }

    private void Attack()
    {
        if (_isAttacking)
        {
            return;
        }

        _isAttacking = true;
        Animator.AttackAnimation();
        _hitBoxController.EnableHitBox(0.1f, 0.25f);
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        _isAttacking = false;
    }
}
