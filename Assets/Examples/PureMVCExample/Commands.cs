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

public class LoginCommand :SimpleCommand {
    public override void Execute(INotification notification) {

        UserDataProxy proxy = Facade.RetrieveProxy(UserDataProxy.NAME) as UserDataProxy;
        string message = notification.Body.ToString();
        int split = message.IndexOf("/");
        string email = message.Substring(0, split);
        string password = message.Substring(split);
        proxy.SetProperty(email, password);

        NetManager.Instance.Send(notification.Body);
    }
}