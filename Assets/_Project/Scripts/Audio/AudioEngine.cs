using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngine : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSourceEngeni;
    private float minAudio = 0.01f;
    private float currentVloume;
    private void Start()
    {
        currentVloume = minAudio;
        audioSourceEngeni.volume = minAudio;
    }
    public void ControlEngineVloume(float speed)
    {

        currentVloume = minAudio + minAudio * speed * 20;

        audioSourceEngeni.volume = currentVloume;
    }
}
