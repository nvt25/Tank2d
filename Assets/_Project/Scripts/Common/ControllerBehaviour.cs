using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected int healthPoint;
    protected int currentHealthPoint;
    [SerializeField]
    protected string bulletType;
    [SerializeField]
    protected EventAttack eventAttack;
    [SerializeField]
    protected List<Transform> pointsSpawnBullet;
    [SerializeField]
    protected Rigidbody2D rgb2D;
    [SerializeField]
    protected Detector detector;
    public abstract void Init();
    public abstract void HandleMove(Vector2 movement);
    public abstract void HandleAttack();
    public abstract void HandleTurnTarget(Vector3 pointTarget);
    protected abstract void HandleHit(float pecentHp);
    protected abstract void HandleDie();
    protected virtual void OnEnable()
    {
        currentHealthPoint = healthPoint;
        Init();
    }
    public void Damage(float damage)
    {
        currentHealthPoint -= (int)damage;
        if (currentHealthPoint > 0)
        {
            HandleHit((float)currentHealthPoint / healthPoint);
        }
        else
        {
            currentHealthPoint = 0;
            HandleDie();
        }
    }
    public EventAttack GetEventAttack
    {
        get { return eventAttack; }
    }
}
