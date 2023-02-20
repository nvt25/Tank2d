using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float damageRoot;
    private float damage;
    public void Shoot(float percent, Transform pointShoot)
    {
        this.damage = (damageRoot * percent) / 100 + damageRoot;
        _rb.AddForce(pointShoot.up * StaticData.bulletForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(damage);
        }
    }
}
