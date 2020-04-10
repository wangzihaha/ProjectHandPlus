using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginPanelMediator : Mediator
{
    public new const string NAME = "LoginPanelMediator";
    //private LoginPanelView view;
    private readonly UserDataProxy userDataProxy;

    public LoginPanelMediator(object viewComponent):base(NAME, viewComponent) {
        ((LoginPanelView)ViewComponent).loginBtn.onClick.AddListener(OnClickLogin);
        userDataProxy = Facade.RetrieveProxy(UserDataProxy.NAME) as UserDataProxy;
    }

    private void OnClickLogin() {
        string email = ((LoginPanelView)ViewComponent).emailText.text;
        string password = ((LoginPanelView)ViewComponent).passwordText.text;
        SendNotification(MyFacade.Login, email + "/" + password);
    }

    public override IList<string> ListNotificationInterests() {
        return new List<string>() { MyFacade.LoginSucceed, MyFacade.LoginFailed};
    }

    public override void HandleNotification(INotification notification) {
        switch (notification.Name) {
            case MyFacade.LoginSucceed:
                ((LoginPanelView)ViewComponent).messageText.text = "succeed";
                break;
            case MyFacade.LoginFailed:
                ((LoginPanelView)ViewComponent).messageText.text = "failed";
                break;
            default:
                break;
        }
    }
}
