using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAttack : MonoBehaviour
{
    [SerializeField]
    private string bulletType;
    [SerializeField]
    private List<Transform> poinList;
    [SerializeField]
    private bool isAttackWithCode;
    private float attackDelayTime;
    public UnityEvent shootSound;
    private void Update()
    {
        if (attackDelayTime > 0)
        {
            attackDelayTime -= Time.deltaTime;
        }
    }
    public void InitEventAttack(object[] parameter)
    {
        bulletType = (string)parameter[0];
        poinList = (List<Transform>)parameter[1];
        //isAttackWithCode = (bool)parameter[2];
    }

    public void Attack()
    {
        shootSound?.Invoke();
        if (isAttackWithCode)
        {
            //call from code
            if (attackDelayTime <= 0)
            {
                SpawnBullet();
                attackDelayTime = 4f;
            }
        }
        else
        {
            // call from anim
            SpawnBullet();
        }

    }
    private void SpawnBullet()
    {
        foreach (Transform point in poinList)
        {
            if (point.gameObject.activeInHierarchy)
            {
                InitOnNewGame.Ins.SpanwBullet(bulletType, point);
                // fix ing
                InitOnNewGame.Ins.SpanwVfx("Shoot", point);
            }
        }
    }
}
