using BASE.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerControl : ControllerBehaviour
{
    [SerializeField]
    private Transform hull;
    [SerializeField]
    private Transform track;
    [SerializeField]
    private Transform tower;
    [SerializeField]
    private Joystick joystick;
    private Vector2 valueDirectionInitial;
    private Vector2 movement;
    float angle;
    [SerializeField]
    private Animator _tracksAnim;
    [SerializeField]
    private Animator _attackAnim;
    [SerializeField]
    private float speed = 1.5f;
    public Image img;
    private int coinInGame;
    private IReceiveItem item;
    [SerializeField]
    private LayerMask layerItem;
    public UnityEvent<float> controlAudio = new UnityEvent<float>();
    private Vector3 lastPosition;
    public override void HandleAttack()
    {
        _attackAnim.SetBool("IsAttack", detector.targetVisible);
        if (detector.targetVisible)
        {
            HandleTurnTarget(new Vector3(0f, 0f, GetAngleEnemy()));
        }
        else
        {
            HandleTurnTarget(new Vector3(0f, 0f, angle));
        }
    }

    public override void HandleMove(Vector2 movement)
    {
        this.movement = movement;
        Vector2 lookDir = movement - valueDirectionInitial;
        controlAudio?.Invoke(lookDir.magnitude);
        _tracksAnim.SetFloat("Run", lookDir.magnitude);
        if (lookDir != Vector2.zero)
        {
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        };
    }

    public override void HandleTurnTarget(Vector3 pointTarget)
    {
        tower.localRotation = Quaternion.Euler(pointTarget);
    }

    public override void Init()
    {
        GameManager.Ins.audioListener.enabled = false;
        currentHealthPoint = healthPoint;
        coinInGame = 0;
        joystick = GameManager.Ins.getJoystick;
        if (joystick == null) return;
        valueDirectionInitial = joystick.Direction;
        _attackAnim.SetBool("IsAttack", false);
        setBody(DynamicData.Ins.selectedId.CodeID);
        img.fillAmount = 1;
    }

    public void Move()
    {
        rgb2D.MovePosition(rgb2D.position + this.movement * speed * Time.fixedDeltaTime);

        hull.localRotation = Quaternion.Euler(0f, 0f, angle);
        track.localRotation = Quaternion.Euler(0f, 0f, angle);
        if(Vector2.Distance(lastPosition,transform.position)>0.2)
        {
            lastPosition = transform.position;
            InitOnNewGame.Ins.spawTankVestige(track);
        }
    }

    protected override void HandleDie()
    {
        GameManager.Ins.audioListener.enabled = true;

        gameObject.SetActive(false);
        CanvaManager.Ins.OpenUI(StaticData.LOSE, new object[] { coinInGame });
    }

    protected override void HandleHit(float pecentHp)
    {
        img.fillAmount = pecentHp;
        //Hit Anim
    }
    private void Update()
    {
        if (joystick == null) return;
        HandleAttack();
        ScanItemNearPlayer();
        HandleMove(joystick.Direction);

    }
    private void FixedUpdate()
    {
        Move();
    }
    private float GetAngleEnemy()
    {
        Vector2 lookDir = detector.Target.position - hull.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        return angle;
    }

    public void setTrack(string nameTrack)
    {
        switch (nameTrack)
        {
            case "TrackA":
                speed = 1f;
                _tracksAnim.SetFloat("IdTracks", 0f);
                break;
            case "TrackB":
                _tracksAnim.SetFloat("IdTracks", 0.333f);
                speed = 1.5f;
                break;
            case "TrackC":
                _tracksAnim.SetFloat("IdTracks", 0.666f);
                speed = 2f;
                break;
            case "TrackD":
                _tracksAnim.SetFloat("IdTracks", 1f);
                speed = 2.5f;
                break;
            default:
                _tracksAnim.SetFloat("IdTracks", 0f);
                speed = 1f;
                break;
        }
    }
    public void setBody(int id)
    {
        switch (id)
        {
            case 1:
                bulletType = "LightShell";
                speed = 1f;
                break;
            case 2:
                bulletType = "LightShell";

                speed = 1.25f;
                break;
            case 3:
                bulletType = "LightShell";

                speed = 1.5f;
                break;
            case 4:
                bulletType = "MediumShell";

                speed = 1.75f;
                break;
            case 5:
                bulletType = "MediumShell";

                speed = 2f;
                break;
            case 6:
                bulletType = "MediumShell";

                speed = 2.25f;
                break;
            case 7:
                bulletType = "HeavyShell";

                speed = 2.5f;
                break;
            case 8:
                bulletType = "HeavyShell";

                speed = 2.75f;
                break;
            case 9:
                bulletType = "HeavyShell";

                speed = 3f;
                break;
            default:
                bulletType = "LightShell";

                speed = 1f;
                break;
        }
        _attackAnim.SetFloat("IdTank", (id - 1) * 0.125f);
        eventAttack.InitEventAttack(new object[] { bulletType, pointsSpawnBullet });
    }
    private void ScanItemNearPlayer()
    {
        if (item == null)
        {
            Collider2D tempItem = Physics2D.OverlapCircle(transform.position, 2.5f, layerItem);
            if (tempItem != null) item = tempItem.GetComponent<IReceiveItem>();
        }
        else
        {
            item.ReceiveItem();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinInGame += 1;
            collision.gameObject.SetActive(false);
            item = null;
        }
        if (collision.CompareTag("PassWin"))
        {
            CanvaManager.Ins.OpenUI(StaticData.WIN, new object[] { coinInGame });
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 2.5f);
    }
}
