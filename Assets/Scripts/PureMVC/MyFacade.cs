using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class MyFacade : Facade {
    public const string StartUp = "start_up";
    public const string Login = "login";
    public const string LoginSuccess = "login_succeed";
    public const string LoginFailure = "login_failed";

    static MyFacade() {
        m_instance = new MyFacade();
    }

    public static MyFacade GetInstance() {
        return m_instance as MyFacade;
    }

    protected override void InitializeController() {
        base.InitializeController();
        RegisterCommand(StartUp, typeof(StartUpCommand));
        RegisterCommand(Login, typeof(LoginCommand));

        // 从消息中心监听服务器发来的事件，将服务器发来的消息存入消息中心由NetworkManager完成
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.LogInSuccess, OnLoginSucess);
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.Failure, OnLoginFailure);
    }

    protected override void InitializeView() {
        base.InitializeView();
    }

    protected override void InitializeModel() {
        base.InitializeModel();
        RegisterProxy(new UserDataProxy(new UserDataModel()));
    }

    private void OnLoginSucess(object data) {
        SendNotification(LoginSuccess);
    }

    private void OnLoginFailure(object data) {
        SendNotification(LoginFailure);
    }

}
