using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineControl : MonoBehaviour
{
    [SerializeField]
    private float damageMine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damage = collision.gameObject.GetComponent<IDamageable>();
            if (damage != null)
            {
                damage.Damage(damageMine);
                Debug.Log("damage mine");
                InitOnNewGame.Ins.SpanwVfx("b", transform);
                Destroy(gameObject);
            }
        }
    }
}
