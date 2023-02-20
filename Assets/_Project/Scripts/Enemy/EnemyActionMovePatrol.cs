using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionMovePatrol : ActionBehaviour
{
    [SerializeField]
    private EnemyPatrolPath patrolPath;
    private float arriveDistance = 0.5f;
    private float waitTime = 0.5f;
    [SerializeField]
    private bool isWaiting = false;
    [SerializeField]

    private Vector2 currentPatrolTarget = Vector2.zero;
    private int currentIndex;

    private bool isInitialized = false;
    public override void PerformAction(ControllerBehaviour control, Detector detector)
    {
        if (!isWaiting)
        {
            if (patrolPath.LengthPoint == 0) return;
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetPointNearTank(control.transform.position);
                currentPatrolTarget = currentPathPoint.position;
                currentIndex = currentPathPoint.index;
                isInitialized = true;
            }
            if (Vector2.Distance(control.transform.position, currentPatrolTarget) <= arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }
            Vector2 directionToGo = currentPatrolTarget - (Vector2)control.transform.position;
            float dotProduct = Vector2.Dot(control.transform.up, directionToGo.normalized);
            if (dotProduct < 0.98f)
            {
                // khong cung huowng thii quay
                Vector3 crossProduct = Vector3.Cross(control.transform.up, directionToGo.normalized);
                int rotation = crossProduct.z >= 0 ? -1 : 1;
                control.HandleMove(new Vector2(rotation, 1));
            }
            else
            {
                control.HandleMove(Vector2.up); ;

            }

            //control.HandleMove(currentPatrolTarget);
        }
    }
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        var currentPathpoint = patrolPath.NextPoint(currentIndex);
        currentIndex = currentPathpoint.index;
        currentPatrolTarget = currentPathpoint.position;
        isWaiting = false;
    }
}
