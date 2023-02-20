using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControlInGame : MonoBehaviour, IReceiveItem
{
    private float speed = 10;
    public void ReceiveItem()
    {
        // Push Coin
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Ins.player.transform.position, step);
    }
}
