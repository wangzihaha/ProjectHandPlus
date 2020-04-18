using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class RoomListPanelMediator : Mediator
{
    public new const string NAME = "RoomListPanelMediator";


    public RoomListPanelMediator(object viewComponent):base(NAME,viewComponent)
    {
        ((RoomListPanelView)viewComponent).creatButton.onClick.AddListener(OnCreatRoom);
        ((RoomListPanelView)viewComponent).selectButton.onClick.AddListener(OnSelectRoom);
        ((RoomListPanelView)viewComponent).downButton.onClick.AddListener(delegate { OnChangePage(1); });
        ((RoomListPanelView)viewComponent).firstButton.onClick.AddListener(delegate { OnChangePage(-999); });
        ((RoomListPanelView)viewComponent).lastButton.onClick.AddListener(delegate { OnChangePage(999); });
        ((RoomListPanelView)viewComponent).upButton.onClick.AddListener(delegate { OnChangePage(-1); });
        ((RoomListPanelView)viewComponent).pageNum.text = "1/1";
        Facade.RegisterProxy(new RoomListProxy(new RoomListModel(10, 30)));
        
    }

    private void OnChangePage(int dPage)
    {
        RoomListProxy roomListProxy = ((RoomListProxy)Facade.RetrieveProxy(RoomListProxy.NAME));
        roomListProxy.ChangePage(dPage);
        ((RoomListPanelView)ViewComponent).pageNum.text = roomListProxy.data.curPage + "/" + roomListProxy.data.maxPage;
    }

    private void OnSelectRoom()
    {

    }

    private void OnCreatRoom()
    {
        RoomInfoModel tem = new RoomInfoModel();
        tem.id = UnityEngine.Random.Range(0, 100);
        tem.roomName = UnityEngine.Random.Range(0, 100).ToString();
        tem.mapName = UnityEngine.Random.Range(0, 100).ToString();
        tem.master = UnityEngine.Random.Range(0, 100);


        ((RoomInfoProxy)Facade.RetrieveProxy(RoomInfoProxy.NAME)).AddRoomInfo(tem);

        SendNotification(MyFacade.RefreshRoomList);
    }
}
