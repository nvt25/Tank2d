using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionAttack : ActionBehaviour
{
    [SerializeField]
    private float visionForShooting;
    public override void PerformAction(ControllerBehaviour control, Detector detector)
    {

        if (CheckTargetInVision(control, detector))
        {
            control.HandleAttack();
            control.HandleMove(Vector2.zero);

        }
        else
        {
            control.GetEventAttack.GetComponent<Animator>().SetBool("IsAttack", false);
        }
        control.HandleTurnTarget(detector.Target.position);
    }
    private bool CheckTargetInVision(ControllerBehaviour control, Detector detector)
    {
        Vector3 direction = detector.Target.position - control.GetEventAttack.transform.parent.position;
        if (Vector3.Angle(control.GetEventAttack.transform.parent.right, direction) < visionForShooting / 2)
        {
            return true;
        }
        return false;
    }
}
