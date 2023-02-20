using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPath : MonoBehaviour
{
    [SerializeField]
    private List<Transform> listPoints;
    public struct InfoPoint
    {
        public int index;
        public Vector2 position;
    }
    public InfoPoint GetPointNearTank(Vector2 pos)
    {
        float min = float.MaxValue;
        int index = -1;
        for(int i =0;i<listPoints.Count;i++)
        {
            float distance = Vector3.Distance(pos, listPoints[i].position);
            if(distance < min)
            {
                min = distance;
                index = i;
            }
        }
        return new InfoPoint{ index = index,position = listPoints[index].position };
    }
    public InfoPoint NextPoint(int index)
    {
        int newIndex = index >= listPoints.Count-1 ? 0 : index + 1;
        return new InfoPoint { index = newIndex,position = listPoints[newIndex].position};
    }
    public int LengthPoint { get { return listPoints.Count; } }
    [Header("Gizmo parametter")]
    public Color pointColor = Color.blue;
    public Color lineColor = Color.red;
    public float pointSize = 0.1f;
    private void OnDrawGizmos()
    {
        if (LengthPoint <= 0) return;
        for(int i = LengthPoint - 1; i >= 0; i--)
        {
            if (listPoints[i] == null) return;
            Gizmos.color = pointColor;
            Gizmos.DrawSphere(listPoints[i].position, pointSize);
            if (i == 0||LengthPoint == 1) return;
            Gizmos.color = lineColor;
            Gizmos.DrawLine(listPoints[i].position, listPoints[i - 1].position);
            if (LengthPoint > 2 && i == LengthPoint - 1)
            {
                Gizmos.DrawLine(listPoints[i].position, listPoints[0].position);
            }
        }
    }
}
