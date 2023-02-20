using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSourceEffect;
    [SerializeField]
    private AudioClip value;
    public void Control()
    {
        audioSourceEffect.PlayOneShot(value);
    }
}
