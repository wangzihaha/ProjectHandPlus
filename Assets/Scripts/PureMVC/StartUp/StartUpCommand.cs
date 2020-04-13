using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartUpCommand : SimpleCommand {
    public override void Execute(INotification notification) {
        Debug.Log("StartUpCommand: hello!");
        LoginPanelView loginPanelView = GameObject.Find("LoginPanel").GetComponent<LoginPanelView>();
        Facade.RegisterMediator(new LoginPanelMediator(loginPanelView));
    }
}