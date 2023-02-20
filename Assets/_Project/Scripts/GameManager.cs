using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : Singleton<GameManager>
{
    public PlayerControl player;
    public Joystick getJoystick;
    public float lengthRoom;
    public Action<int> CreatControl;
    public AudioListener audioListener;
    public AudioSource bgMusic;
}
