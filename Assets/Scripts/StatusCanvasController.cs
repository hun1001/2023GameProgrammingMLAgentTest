using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusCanvasController : MonoBehaviour
{
    [SerializeField]
    private Image _hpBar = null;

    [SerializeField]
    private Image _delayBar = null;

    public void SetHpBar(float hp, float maxHp)
    {
        _hpBar.fillAmount = hp / maxHp;
    }

    public void SetHpBar(float hp)
    {
        _hpBar.fillAmount = hp;
    }

    public void SetDelayBar(float delay, float maxDelay)
    {
        _delayBar.fillAmount = delay / maxDelay;
    }

    public void SetDelayBar(float delay)
    {
        _delayBar.fillAmount = delay;
    }
}
