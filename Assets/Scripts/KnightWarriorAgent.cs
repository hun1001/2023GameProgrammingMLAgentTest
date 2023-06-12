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

    protected override void Awake()
    {
        _inputController.DisableUserInput();
    }

    public override void Initialize()
    {

    }

    public override void OnEpisodeBegin()
    {

    }

    public override void CollectObservations(VectorSensor sensor)
    {

    }

    public override void OnActionReceived(ActionBuffers actions)
    {

    }
}
