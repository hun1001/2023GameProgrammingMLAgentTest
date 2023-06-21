using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class KnightWarriorAgent : Agent
{
    [SerializeField]
    private PlayerInputController _inputController = null;

    private DuelManager _duelManager = null;
    private Player _otherPlayer = null;

    protected override void Awake()
    {
        _inputController.DisableUserInput();
    }

    public override void Initialize()
    {
        _duelManager = FindObjectOfType<DuelManager>();
        _otherPlayer = _duelManager.GetOtherPlayer(GetComponent<Player>());

        _inputController.GetComponent<PlayerDamaged>().AddOnDeadAction(EndEpisode);
        _inputController.GetComponent<PlayerDamaged>().AddOnDamagedAction(() => AddReward(-5f));

        MaxStep = 10000;
    }

    public override void OnEpisodeBegin()
    {
        _duelManager.ResetDuel();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Vector3.Distance(transform.position, _otherPlayer.transform.position));
        sensor.AddObservation(_otherPlayer.transform.position);
        sensor.AddObservation(transform.position);

        sensor.AddObservation(_otherPlayer.GetComponent<PlayerDamaged>().Hp);
        sensor.AddObservation(GetComponent<PlayerDamaged>().Hp);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var moveAction = actions.DiscreteActions[0];
        var attackAction = actions.DiscreteActions[1];

        switch (moveAction)
        {
            case 0:
                _inputController.OnArrowInput(0, 1);
                break;
            case 1:
                _inputController.OnArrowInput(0, -1);
                break;
            case 2:
                _inputController.OnArrowInput(1, 1);
                break;
            case 3:
                _inputController.OnArrowInput(1, -1);
                break;
            case 4:
                _inputController.OnArrowInput(1, 0);
                break;
            case 5:
                _inputController.OnArrowInput(0, 0);
                _inputController.OnArrowInputRelease();
                break;
            case 6:
                _inputController.OnArrowInput(-1, 0);
                break;
            case 7:
                _inputController.OnArrowInput(-1, 1);
                break;
            case 8:
                _inputController.OnArrowInput(-1, -1);
                break;
        }

        Vector3 mousePosition = _otherPlayer.transform.position;
        mousePosition.y = transform.position.y;

        _inputController.OnMousePositionInput(_otherPlayer.transform.position);

        if (attackAction == 1)
        {
            _inputController.OnAttackInput();
        }

        AddReward(-0.01f);
    }
}
