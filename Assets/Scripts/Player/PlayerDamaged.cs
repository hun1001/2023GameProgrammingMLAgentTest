using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField]
    private StatusCanvasController _statusCanvasController = null;

    private float _maxHp = 100f;
    private float _hp = 100f;

    public void Damaged(float damage)
    {
        _hp -= damage;
        _statusCanvasController.SetHpBar(_hp, _maxHp);
    }
}