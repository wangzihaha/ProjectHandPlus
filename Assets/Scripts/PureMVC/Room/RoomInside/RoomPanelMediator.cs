using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System;

public class RoomPanelMediator : Mediator
{
    public new const string NAME = "RoomPanelMediator";

    public RoomPanelMediator(object viewComponent, bool isMaster) : base(NAME, viewComponent)
    {
        ((RoomPanelView)ViewComponent).changeRoleBtn.onClick.AddListener(OnChangeRole);
        ((RoomPanelView)ViewComponent).outRoomBtn.onClick.AddListener(OnOutRoom);
        ((RoomPanelView)ViewComponent).readyBtn.onClick.AddListener(OnReady);
        ((RoomPanelView)ViewComponent).startBtn.onClick.AddListener(OnStart);
        ((RoomPanelView)ViewComponent).startBtn.gameObject.SetActive(isMaster);

        string mapName = ((RoomInfoProxy)Facade.RetrieveProxy(RoomInfoProxy.NAME)).myRoom.MapName;

        ((RoomPanelView)ViewComponent).mapPreview.sprite = ResourceTool.Instance.GetMapPreview(mapName);
    }

    private void OnStart()
    {
        
    }

    private void OnReady()
    {
        
    }

    private void OnOutRoom()
    {
        GameObject roomListPanel = ((RoomListPanelView)Facade.RetrieveMediator(RoomListPanelMediator.NAME).ViewComponent).gameObject;
        roomListPanel.SetActive(true);

        GameObject roomPanel = ((RoomPanelView)Facade.RetrieveMediator(RoomPanelMediator.NAME).ViewComponent).gameObject;
        Facade.RemoveMediator(RoomPanelMediator.NAME);
        GameObject.Destroy(roomPanel);
    }

    private void OnChangeRole()
    {
        GameObject selectRolePanel = (GameObject)GameObject.Instantiate(ResourceTool.Instance.SelectRolePanel);
        SelectRolePanelView selectRolePanelView = selectRolePanel.GetComponent<SelectRolePanelView>();
        Facade.RegisterMediator(new SelectRolePanelMediator(selectRolePanelView));


        GameObject roomPanel = ((RoomPanelView)Facade.RetrieveMediator(RoomPanelMediator.NAME).ViewComponent).gameObject;
        roomPanel.SetActive(false);
    }
}
