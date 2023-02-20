using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager Ins;


    public PlayerControl player;
    public Joystick getJoystick;
    public float lengthRoom;
    public Action<int> CreatControl;
    public AudioListener audioListener;
    public AudioSource bgMusic;
    private void Awake()
    {
        Ins = this;
    }
}
