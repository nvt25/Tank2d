using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyControl : ControllerBehaviour
{
    [SerializeField]
    private ActionBehaviour attackAcrion, moveAction;
    [SerializeField]
    private Transform barHP;
    [SerializeField]
    float hight;
    float CurrentSpeed;
    float Speed = 20;
    Vector2 movement = Vector2.zero;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Animator animTrack;

    public override void Init()
    {
        eventAttack.InitEventAttack(new object[] { bulletType, pointsSpawnBullet });

        barHP.GetChild(0).localScale = new Vector3(currentHealthPoint / healthPoint, 1f, 1f);
        int temp = Random.Range(0, 3);
        anim.SetFloat("IdTurret", temp * 0.5f);
    }
    public override void HandleAttack()
    {
        if (eventAttack)
        {
            eventAttack.GetComponent<Animator>().SetBool("IsAttack", true);
        }
        else
        {
            //Shoot Delay With Funtion Update
            eventAttack.Attack();
        }
    }


    public override void HandleMove(Vector2 movement)
    {
        this.movement = movement;
        if (movement == Vector2.zero)
        {
            CurrentSpeed = 0;
        }
        else
        {
            CurrentSpeed = Speed;
        }
        if (animTrack)
        {
            animTrack.SetFloat("Run", CurrentSpeed);
        }
    }

    public override void HandleTurnTarget(Vector3 pointTarget)
    {
        Vector3 turretDirection = (Vector3)pointTarget - eventAttack.transform.parent.position;

        float desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

        float rotationStep = 50 * Time.deltaTime;
        eventAttack.transform.parent.rotation = Quaternion.RotateTowards(eventAttack.transform.parent.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationStep);
    }
    protected override void HandleHit(float percentHp)
    {
        barHP.GetChild(0).localScale = new Vector3(percentHp, 1f, 1f);
    }

    protected override void HandleDie()
    {
        int numberCoin = Random.Range(3, 10);
        for (int i = 0; i < numberCoin; i++)
        {
            Vector2 tempLocation = Random.insideUnitCircle;
            InitOnNewGame.Ins.spawCoin((Vector2)transform.position + tempLocation);
        }
        if (DynamicData.Ins.Vibrate)
        {
            Handheld.Vibrate();
            Debug.Log("RUng");
        }
        InitOnNewGame.Ins.SpanwVfx("Explode", transform);
        gameObject.SetActive(false);
        barHP.gameObject.SetActive(false);
    }
    // End Handle


    protected void Update()
    {
        HandleAttackOrMove();
        BarHpOnEnemy();
    }
    private void HandleAttackOrMove()
    {
        if (detector.targetVisible)
        {
            attackAcrion.PerformAction(this, detector);
        }
        else
        {
            moveAction.PerformAction(this, detector);
            GetEventAttack.GetComponent<Animator>().SetBool("IsAttack", false);
        }
    }
    private void BarHpOnEnemy()
    {
        barHP.position = transform.position + new Vector3(0, hight, 0);
    }
    protected void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        rgb2D.velocity = (Vector2)transform.up * CurrentSpeed * Time.fixedDeltaTime;
        rgb2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movement.x * 100 * Time.deltaTime));
    }
}
