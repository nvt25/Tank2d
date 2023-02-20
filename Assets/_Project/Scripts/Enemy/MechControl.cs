using UnityEngine;
using UnityEngine.AI;

public class MechControl : MonoBehaviour
{
//    [SerializeField]
//    private Animator _anim;
//    [SerializeField]
//    protected Transform model;
//    [SerializeField]
//    protected EventAttack eventAttack;
//    [SerializeField]
//    private NavMeshAgent agent;
//    private Transform playerTf;
//    protected override void InitEnemy()
//    {
//        agent.updateRotation = false;
//        agent.updateUpAxis = false;
//        playerTf = GameManager.Ins.player.transform;
//        eventAttack.InitEventAttack(new object[] { bulletType, _pointList });
//    }
//    protected override void MovementEnemy()
//    {
//        if (vtTarget.magnitude > distanceCanAttack - 1f)
//        {
//            agent.SetDestination(playerTf.position);
//        }
//        else { agent.ResetPath(); }
//        vtTarget = playerTf.position - transform.position;
//        float angle = Mathf.Atan2(vtTarget.y, vtTarget.x) * Mathf.Rad2Deg - 90f;
//        model.rotation = Quaternion.Euler(0f, 0f, angle);
//    }

//    protected override void AttackEnemy()
//    {
//        if (vtTarget.magnitude <= distanceCanAttack)
//        {
//            _anim.SetBool("IsAttack", true);
//        }
//        else
//        {
//            _anim.SetBool("IsAttack", false);
//        }
//    }

//    protected override void EnemyDie()
//    {
//        //vfx exploer 
//    }
}
