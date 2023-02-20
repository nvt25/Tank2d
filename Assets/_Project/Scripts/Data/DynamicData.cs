using System.Collections.Generic;
using UnityEngine;

public class DynamicData : MonoBehaviour
{
    public static DynamicData Ins;
    public bool isLoadedBase = false;
    public UnityEngine.Events.UnityEvent loadDataPlayer;
    private bool vibrate;
    private bool music;
    private int coin;
    private int currentLevel;
    private int openLevel;

    [SerializeField]
    private int totalLevel;

    public List<PlayerMode> listModelPlayer = new List<PlayerMode>();
    public PlayerMode selectedId;

    private void Awake()
    {
        Ins = this;
    }

    private void Start()
    {
        //Call Frist with UI
        BASE.UI.CanvaManager.Ins.OpenUI(StaticData.LOADING, new object[] { });
        vibrate = PlayerPrefs.GetInt(StaticData.Vibrate, 1) == 1 ? true : false;
        music = PlayerPrefs.GetInt(StaticData.Music, 1) == 1 ? true : false;
        coin = PlayerPrefs.GetInt(StaticData.Coin, 2000);
        openLevel = PlayerPrefs.GetInt(StaticData.Level, 1);
        currentLevel = openLevel;
        isLoadedBase = true;
    }

    public int GetStatusMode(string codeId)
    {
        return PlayerPrefs.GetInt(codeId, 0);
    }

    public void SetStatusMode(string codeId, int status)
    {
        PlayerPrefs.SetInt(codeId, status);
    }

    public bool Vibrate
    {
        get => vibrate;
        set
        {
            vibrate = value;
            PlayerPrefs.SetInt(StaticData.Vibrate, value ? 1 : 0);
        }
    }

    public bool Music
    {
        get => music;
        set
        {
            music = value;
            PlayerPrefs.SetInt(StaticData.Music, value ? 1 : 0);
        }
    }

    public int Coin
    {
        get => coin;
        set
        {
            PlayerPrefs.SetInt(StaticData.Coin, value);
            coin = value;
        }
    }

    public int CurrentLevel
    {
        get => currentLevel;
        set
        {
            currentLevel = value;
            if (value > totalLevel)
            {
                currentLevel = 1;
                return;
            }
            if (value > openLevel)
            {
                OpenLevel = value;
            }
        }
    }

    public int OpenLevel
    {
        get => openLevel;
        set
        {
            openLevel = value;
            PlayerPrefs.SetInt(StaticData.Level, value);
        }
    }
}