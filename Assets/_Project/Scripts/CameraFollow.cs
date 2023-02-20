using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 location;
    private void LateUpdate()
    {
        if (!GameManager.Ins.player.gameObject.activeSelf) return;
        location.y = GameManager.Ins.player.transform.position.y;
        location.x = GameManager.Ins.player.transform.position.x;
        location.z = -10f;
        if (location.x > 2.8f)
        {
            location.x = 2.8f;
        }
        if (location.x < -3.6f)
        {
            location.x = -3.6f;
        }
        if (location.y < 5f)
        {
            location.y = 5f;
        }
        if (location.y > GameManager.Ins.lengthRoom - 4.5f)
        {
            location.y = GameManager.Ins.lengthRoom - 4.5f;
        }
        transform.position = location;
    }
}
