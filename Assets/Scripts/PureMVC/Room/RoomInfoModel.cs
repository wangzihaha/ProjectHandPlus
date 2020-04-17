using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfoModel 
{
    public int id;
    public int roundTime;
    public int roundNumber;
    public string roomName;
    public string mapName;
    public string password;
    public int maxPlayers;
    public List<int> preparedPlayers = new List<int>();
    public List<int> unPreparedPlayers = new List<int>();
    public int master;
}
