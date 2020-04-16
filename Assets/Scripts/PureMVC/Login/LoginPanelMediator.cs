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
        string _email = ((LoginPanelView)ViewComponent).emailText.text;
        string _password = ((LoginPanelView)ViewComponent).passwordText.text;
        UserDataModel message = new UserDataModel {
            email = _email,
            password = _password
        };
        SendNotification(MyFacade.Login, message);
    }

    public override IList<string> ListNotificationInterests() {
        return new List<string>() { MyFacade.LoginSuccess, MyFacade.LoginFailure};
    }

    public override void HandleNotification(INotification notification) {
        switch (notification.Name) {
            case MyFacade.LoginSuccess:
                ((LoginPanelView)ViewComponent).messageText.text = "succeed";
                break;
            case MyFacade.LoginFailure:
                ((LoginPanelView)ViewComponent).messageText.text = "failed";
                break;
            default:
                break;
        }
    }
}
