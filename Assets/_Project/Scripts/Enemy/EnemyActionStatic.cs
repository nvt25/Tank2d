using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionStatic : ActionBehaviour
{
    private float patrolDelayTime = 4;
    private float patrolWaitTime;
    private Vector2 ramdomDirection = Vector2.zero;
    private void Awake()
    {
        ramdomDirection = Random.insideUnitCircle;
    }
    public override void PerformAction(ControllerBehaviour control, Detector detector)
    {
        float angle = Vector2.Angle(control.GetEventAttack.transform.parent.right, ramdomDirection);
        if (patrolWaitTime <= 0 && angle < 2)
        {
            ramdomDirection = Random.insideUnitCircle;
            patrolWaitTime = patrolDelayTime;
        }
        else
        {
            if (patrolWaitTime > 0)
            {
                patrolWaitTime -= Time.deltaTime;
            }
            else
            {
                control.HandleTurnTarget((Vector2)control.GetEventAttack.transform.parent.position + ramdomDirection);
            }
        }
    }
}
