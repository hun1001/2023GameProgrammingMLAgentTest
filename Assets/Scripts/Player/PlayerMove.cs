using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerAction
{
    [SerializeField]
    private float _speed = 10f;

    private void Awake()
    {
        InputController.OnArrowInput = Move;
        InputController.OnArrowInputRelease = Stop;
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        Animator.MoveAnimation();
    }

    private void Stop()
    {
        transform.Translate(Vector3.zero);
        Animator.StopAnimation();
    }
}
