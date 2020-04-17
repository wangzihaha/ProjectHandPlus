using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshRoomListCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        RoomListPanelMediator roomListPanelMediator = (RoomListPanelMediator)Facade.RetrieveMediator(RoomListPanelMediator.NAME);
        RoomInfoProxy roomInfoProxy = (RoomInfoProxy)Facade.RetrieveProxy(RoomInfoProxy.NAME);
        RoomListProxy roomListProxy = (RoomListProxy)Facade.RetrieveProxy(RoomListProxy.NAME);

        int pageRoomNum = roomListProxy.data.pageRoomNum;

        int maxPage = roomInfoProxy.roomInfos.Count == 0 ? 1 : (roomInfoProxy.roomInfos.Count - 1) / pageRoomNum + 1;
        int curPage = roomListProxy.data.curPage;
        curPage = Mathf.Max(1, curPage);
        curPage = Mathf.Min(maxPage, curPage);
        roomListProxy.data.maxPage = maxPage;
        roomListProxy.data.curPage = curPage;



        RoomListPanelView roomListPanelView = (RoomListPanelView)roomListPanelMediator.ViewComponent;

        for(int i=0;i< roomListPanelView.roomShortInfos.Count;i++)
        {
            GameObject.Destroy(roomListPanelView.roomShortInfos[i]);
        }

        roomListPanelView.roomShortInfos.Clear();

        for(int i = (curPage - 1) * pageRoomNum, posY=0; i < Mathf.Min(curPage * pageRoomNum, roomInfoProxy.roomInfos.Count); i++, posY-=roomListProxy.data.pageRoomGap) 
        {
            GameObject newShortInfo = GameObject.Instantiate(GameObjectTool.Instance.RoomShortInfoView);
            roomListPanelView.roomShortInfos.Add(newShortInfo);
            newShortInfo.transform.SetParent(roomListPanelView.RoomList.transform);
            ((RectTransform)newShortInfo.transform).localPosition = new Vector3(0, posY, 0);
            RoomShortInfoView newView = newShortInfo.GetComponent<RoomShortInfoView>();
            RoomInfoModel roomInfo = roomInfoProxy.roomInfos[i];
            newView.roomID.text = roomInfo.id.ToString();
            newView.roomName.text = roomInfo.roomName;
            newView.mapType.text = roomInfo.mapName;
            newView.master.text = roomInfo.master.ToString();
            int playersInRoom = roomInfo.preparedPlayers.Count + roomInfo.unPreparedPlayers.Count;
            newView.amountText.text = playersInRoom + "/" + roomInfo.maxPlayers;
            
        }

    }
}
