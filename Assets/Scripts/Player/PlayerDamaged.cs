using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField]
    private StatusCanvasController _statusCanvasController = null;

    private Action OnDamagedAction = null;
    public void AddOnDamagedAction(Action action)
    {
        OnDamagedAction += action;
    }

    private Action OnDeadAction = null;
    public void AddOnDeadAction(Action action)
    {
        OnDeadAction += action;
    }

    private float _maxHp = 100f;
    private float _hp = 100f;
    public float Hp => _hp;

    public void HealAllHp()
    {
        _hp = _maxHp;
        _statusCanvasController.SetHpBar(_hp, _maxHp);
    }

    public void Damaged(float damage)
    {
        _hp -= damage;
        _statusCanvasController.SetHpBar(_hp, _maxHp);

        OnDamagedAction?.Invoke();

        if (_hp <= 0f)
        {
            Dead();
        }
    }

    private void Dead()
    {
        OnDeadAction?.Invoke();
    }
}
