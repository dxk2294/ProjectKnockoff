﻿using UnityEngine;

public class WaitTurnState : BaseTurnState
{
    public float waitTime = 2.0f;
    public int loopCount = 3;

    public BaseTurnState nextState;

    private float secondsTimer = 0.0f;
    private int secondsPassed = 0;

    private float timer = 0.0f;
    private int iterations = 0;

    public override void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        // No-op, we don't care about events here.
        // Normally this is where you would transition to another State
        // based on some other event happening.
    }

    public override void OnEnterState()
    {
        base.OnEnterState();

        secondsTimer = 0.0f;
        secondsPassed = 0;

        timer = 0.0f;
        iterations = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        secondsTimer += Time.deltaTime;

        if (secondsTimer >= 1.0f)
        {
            secondsTimer = 0.0f;
            secondsPassed += 1;
            Debug.Log($"{gameObject.name} seconds passed: {secondsPassed}");
        }

        if (timer >= waitTime)
        {
            timer = 0.0f;
            iterations += 1;
 
            secondsTimer = 0.0f;
            secondsPassed = 0;

            Debug.Log($"Updating loop count for {gameObject.name}");
        }

        if (iterations >= loopCount)
        {
            Debug.Log($"State {gameObject.name} hit iteration count, transitioning to next state!");
            stateMachineManager.TransitionToState(nextState);
        }
    }
}