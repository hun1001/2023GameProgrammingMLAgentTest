using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = null;

    private void Awake()
    {
        _animator.SetFloat("Animation Speed", 1f);
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("Trigger");
        _animator.SetInteger("Trigger Number", 2);
    }

    public void MoveAnimation()
    {
        _animator.SetBool("Moving", true);
        _animator.SetFloat("Velocity", 0.8f);
    }

    public void StopAnimation()
    {
        _animator.SetBool("Moving", false);
        _animator.SetFloat("Velocity", 0f);
    }
}
