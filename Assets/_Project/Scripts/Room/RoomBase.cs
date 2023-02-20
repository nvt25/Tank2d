using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private Transform spawnPoint;
    public float GetDistanceRoom
    {
        get {return endPoint.position.y - startPoint.position.y; }
    }
    public Vector3 GetLocation
    {
        get { return spawnPoint.localPosition; }
    }
}
