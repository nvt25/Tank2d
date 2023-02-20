using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 A = new Vector2(1, 2);
        Vector2 B = new Vector2(-1, -2);
        float dotProduct = Vector2.Dot(A, B);
        Debug.Log(dotProduct + "position");
        //Debug.Log(transform.localPosition + "Local");
        //Debug.Log(transform.position-transform.localPosition + "xxxx");
    }


}
