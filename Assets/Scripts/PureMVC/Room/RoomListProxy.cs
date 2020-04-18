using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListProxy : Proxy
{
    public new const string NAME = "RoomListProxy";

    public RoomListModel data;

    public RoomListProxy(object data) : base(NAME, data)
    {
        this.data = (RoomListModel)data;
    }

    public void ChangePage(int dpage)
    {
        data.curPage += dpage;
        Debug.Log(dpage);
        SendNotification(MyFacade.RefreshRoomList);
    }

}
