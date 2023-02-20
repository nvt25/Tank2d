using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarleControl : MonoBehaviour,IDamageable
{
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private Collider2D col;
    public void Damage(float damage)
    {
        _anim.Play("explodingBarrle");
        col.enabled = false;
    }
}
