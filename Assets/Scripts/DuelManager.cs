using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelManager : MonoBehaviour
{
    [SerializeField]
    private Player[] _players = null;

    public void ResetDuel()
    {
        _players[0].transform.position = new Vector3(-10f, 0f, 0f);
        _players[1].transform.position = new Vector3(10f, 0f, 0f);

        _players[0].GetComponent<PlayerDamaged>().HealAllHp();
        _players[1].GetComponent<PlayerDamaged>().HealAllHp();
    }

    public Player GetOtherPlayer(Player player)
    {
        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i] != player)
            {
                return _players[i];
            }
        }

        return null;
    }
}
