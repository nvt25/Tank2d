using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBehaviour : MonoBehaviour
{
    public abstract void PerformAction(ControllerBehaviour control,Detector detector);
}
