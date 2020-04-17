using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class RoomInfoProxy : Proxy
{
    public new const string NAME = "RoomInfo";

    public List<RoomInfoModel> roomInfos;

    public RoomInfoProxy() : base(NAME)
    {
        roomInfos = new List<RoomInfoModel>();
    }
    public void AddRoomInfo(RoomInfoModel roomInfo)
    {
        roomInfos.Add(roomInfo);
    }

    public void RemoveRoomInfo(RoomInfoModel roomInfo)
    {
        roomInfos.Remove(roomInfo);
    }

    public void RemoveRoomInfo(int roomID)
    {
        for(int i=0;i<roomInfos.Count;i++)
        {
            if(roomInfos[i].id==roomID)
            {
                roomInfos.RemoveAt(i);
                break;
            }
        }
    }

    public RoomInfoModel GetRoomInfo(int roomID)
    {
        for (int i = 0; i < roomInfos.Count; i++)
        {
            if (roomInfos[i].id == roomID)
            {
                return roomInfos[i];
            }
        }

        return null;
    }


}
