using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RoomControl : MonoBehaviour
{

    [SerializeField]
    private Transform roomRoot;
    private GameObject roomParent;
    private List<RoomBase> listRoom;
    private List<RoomBase> listRoomComplete;
    private float disntanceRoom;
    private Vector3 spwanLevel;
    [SerializeField]
    private RoomBase roomOverlay;
    [SerializeField]
    private GameObject PassWin;
    private void Start()
    {
        GameManager.Ins.CreatControl = CreatLevel;
    }
    public void CreatLevel(int idLevel)
    {
        if (roomParent != null) Destroy(roomParent);
        InitOnNewGame.Ins.ResetNew();
        roomParent = new GameObject();
        roomParent.name = "RoomParent";
        roomParent.transform.SetParent(roomRoot);
        LevelRoom tempRoom = Resources.Load<LevelRoom>("Levels/Level" + idLevel);
        listRoom = tempRoom.listRoomBase;
        //listRoomComplete.Clear();
        GraftLevel();
    }
    public void GraftLevel()
    {
        disntanceRoom = 0;// 
        spwanLevel = roomParent.transform.position;
        for (int i = 0; i < listRoom.Count; i++)
        {
            if (i == 0)
            {
                CreatRoomOverlay(true);
                CreatRoom(listRoom[i]);
                GameManager.Ins.player.transform.position = listRoom[i].GetLocation;
            }
            else if (i == listRoom.Count - 1)
            {
                CreatRoom(listRoom[i]);
                CreatRoomOverlay(false);
            }
            else
            {
                CreatRoom(listRoom[i]);
            }

        }
    }
    private void CreatRoom(RoomBase roomBase)
    {
        RoomBase tempCreatRoom = Instantiate(roomBase, roomParent.transform);
        spwanLevel.y = disntanceRoom;
        tempCreatRoom.transform.position = spwanLevel;
        disntanceRoom += tempCreatRoom.GetDistanceRoom;
    }
    private void CreatRoomOverlay(bool isFristEnd)
    {
        RoomBase tempCreatRoom = Instantiate(roomOverlay, roomParent.transform);
        if (isFristEnd)
        {
            spwanLevel.y = -tempCreatRoom.GetDistanceRoom;
        }
        else
        {
            GameObject tempPass = Instantiate(PassWin, roomParent.transform);
            spwanLevel.y = disntanceRoom;
            tempPass.transform.position = new Vector3(spwanLevel.x, disntanceRoom - 0.6f, spwanLevel.z);
            //AI Move
            NavMeshSurface2d.Ins.BuildNavMesh();
            GameManager.Ins.lengthRoom = disntanceRoom;
        }
        tempCreatRoom.transform.position = spwanLevel;
    }
}
