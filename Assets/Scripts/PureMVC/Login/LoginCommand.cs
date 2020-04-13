using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class LoginCommand : SimpleCommand {
    public override void Execute(INotification notification) {
        UserDataProxy proxy = Facade.RetrieveProxy(UserDataProxy.NAME) as UserDataProxy;
        string message = notification.Body.ToString();
        int split = message.IndexOf("/");
        string email = message.Substring(0, split);
        string password = message.Substring(split);
        proxy.SetProperty(email, password);

        NetworkManager.Instance.Send(notification.Body);
    }
}
