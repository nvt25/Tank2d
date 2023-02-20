using System;
using System.Collections;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [Range(1, 15)]
    [SerializeField]
    private float viewRadius;

    private float derectorCheckDelay;
    private Transform target = null;

    [SerializeField]
    private LayerMask playerLayerMask;

    [SerializeField]
    private LayerMask visibleLayer;

    [field: SerializeField]
    public bool targetVisible { get; private set; }
    private void Start()
    {
        StartCoroutine(DerectorCoroutine());
        derectorCheckDelay = 0.5f;
    }
    private void OnEnable()
    {
        StartCoroutine(DerectorCoroutine());
        derectorCheckDelay = 0.5f;
        Target = null;
    }
    private void Update()
    {
        if (Target)
        {
            targetVisible = CheckTargetVisible();
            //Debug.Log(CheckTargetVisible());
        }
    }

    /// <summary>
    /// Init when creat object
    /// </summary>
    /// <param name="parametters">values can co</param>
    //public void InitDerector(object[] parametters)
    //{
    //    string nameLayer = (string)parametters[0];
    //    derectorCheckDelay = (float)parametters[1];
    //    playerLayerMask = LayerMask.GetMask(nameLayer);
    //    StartCoroutine(DerectorCoroutine());
    //}
    public Transform Target
    {
        get => target;
        private set
        {
            target = value;
            targetVisible = false;
        }
    }

    private void DerecterTarget()
    {
        if (Target == null)
        {
            FindTargetInRange();
        }
        else
        {
            CheckTargetInRange();
        }
    }

    private void FindTargetInRange()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if (collider)
        {
            Target = collider.transform;
            //Debug.Log("Da thay Muc Tieu");
        }
    }

    private void CheckTargetInRange()
    {
        if (Target == null
            || Target.gameObject.activeSelf == false
            || Vector2.Distance(transform.position, target.position) > viewRadius)
        {
            Target = null;
        }
    }

    private IEnumerator DerectorCoroutine()
    {
        yield return new WaitForSeconds(derectorCheckDelay);
        DerecterTarget();
        StartCoroutine(DerectorCoroutine());
    }

    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visibleLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}