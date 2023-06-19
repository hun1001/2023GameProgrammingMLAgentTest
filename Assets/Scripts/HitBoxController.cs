using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _boxCollider = null;

    private KnightWarriorAgent _knightWarriorAgent = null;
    private bool _isAI = false;

    private void Awake()
    {
        _boxCollider.enabled = false;
        _isAI = TryGetComponent(out _knightWarriorAgent);
    }

    public void EnableHitBox(float delay, float duration)
    {
        StartCoroutine(HitBoxEnableCoroutine(delay, duration));
    }

    public IEnumerator HitBoxEnableCoroutine(float delay, float duration)
    {
        yield return new WaitForSeconds(delay);
        _boxCollider.enabled = true;
        yield return new WaitForSeconds(duration);
        _boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerDamaged playerDamaged = null;
        if (other.TryGetComponent(out playerDamaged))
        {
            playerDamaged.Damaged(10f);

            if (_isAI)
            {
                _knightWarriorAgent.AddReward(4.5f);
            }
        }
        else if (_isAI)
        {
            _knightWarriorAgent.AddReward(-2f);
        }
    }
}
