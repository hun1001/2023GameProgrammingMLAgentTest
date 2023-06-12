using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public void Damaged(float damage)
    {
        Debug.Log($"{gameObject.name} Damaged");
    }
}
