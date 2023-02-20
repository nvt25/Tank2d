using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 2)]
public class LevelRoom : ScriptableObject
{
    public List<RoomBase> listRoomBase;
}
