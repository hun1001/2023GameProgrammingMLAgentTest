using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : PlayerAction
{
    private void Awake()
    {
        InputController.OnMousePositionInput = TryGetComponent<KnightWarriorAgent>(out var w) ? Rotate : RotateMousePosition;
    }

    private void RotateMousePosition(Vector3 target)
    {
        Vector3 targetPos = target;
        Vector3 myPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = targetPos - myPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.down);
    }

    private void Rotate(Vector3 target)
    {
        transform.LookAt(target);
    }
}
