using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    //[SerializeField]
    //private Animator _anim;
    //[SerializeField]
    //protected Transform model;
    //[SerializeField]
    //protected EventAttack eventAttack;
    //protected override void InitEnemy()
    //{
    //    eventAttack.InitEventAttack(new object[] { bulletType, _pointList });
    //}
    //protected override void MovementEnemy()
    //{
    //    Collider2D col = Physics2D.OverlapCircle(transform.position, distanceCanAttack, layerMaskPlayer);
    //    if (col)
    //    {
    //        vtTarget = col.transform.position - transform.position;
    //        float angle = Mathf.Atan2(vtTarget.y, vtTarget.x) * Mathf.Rad2Deg - 90f;
    //        model.rotation = Quaternion.Euler(0f, 0f, angle);
    //    }
    //    else
    //    {
    //        model.rotation = Quaternion.Euler(0f, 0f, 0f);
    //    }
    //}

    //protected override void AttackEnemy()
    //{
    //    if (vtTarget.magnitude <= distanceCanAttack)
    //    {
    //        _anim.SetBool("IsAttack", true);
    //    }
    //    else
    //    {
    //        _anim.SetBool("IsAttack", false);
    //    }
    //}
    //protected override void EnemyDie()
    //{
    //    col.enabled = false;
    //}
}
