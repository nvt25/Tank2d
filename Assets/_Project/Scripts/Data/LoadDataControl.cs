using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadDataControl : MonoBehaviour
{
    private List<PlayerMode> listModelPlayer = new List<PlayerMode>();
    private PlayerMode selectedId;
    public void LoadDataPlayer(string path = "PlayerModel/")
    {
        //call with UnityEvent
        //int a = Resources.LoadAll(path).Length;
        //foreach (PlayerMode mode in Resources.FindObjectsOfTypeAll(typeof(PlayerMode)) as PlayerMode[])
        //{
        //    listModelPlayer.Add(mode);
        //}
        listModelPlayer = Resources.LoadAll<PlayerMode>(path).ToList();
        foreach(PlayerMode mode in listModelPlayer)
        {
            mode.Status = DynamicData.Ins.GetStatusMode(mode.NameModel + mode.CodeID);
            if(mode.Status ==2)
            {
                selectedId = mode;
                //== 0 can not use
                //== 1 can use;
                //== using
            }
        }
        if(selectedId == null)
        {
            selectedId = listModelPlayer[0];
            listModelPlayer[0].Status = 2;
            DynamicData.Ins.SetStatusMode(selectedId.NameModel + selectedId.CodeID, 2);
        }
        DynamicData dnData = DynamicData.Ins;
        dnData.listModelPlayer = listModelPlayer;
        dnData.selectedId = selectedId;
        Destroy(gameObject);
    }
}
