using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using GameProto;
using Google.Protobuf;

public class MyFacade : Facade {
    public const string StartUp = "start_up";
    public const string Login = "login";
    public const string Register = "register";
    public const string RegisterSuccess = "register_succeed";
    public const string RegisterFailure = "register_failed";
    public const string LoginSuccess = "login_succeed";
    public const string LoginFailure = "login_failed";


    //战斗操作指令(上传用)
    public const string BattleUI = "battle_ui";
    public const string CharacterViewUpdata = "character_view_updata";

    //角色信息帧更新
    public const string CharactersFrameUpdata = "characters_frame_updata";


    public const string RefreshRoomList = "refreshRoomList";

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

        RegisterCommand(BattleUI, typeof(BattleUICommand));
        RegisterCommand(CharactersFrameUpdata, typeof(CharactersFrameUpdataCommand));
        //RegisterCommand(CharacterViewUpdata)

        // 从消息中心监听服务器发来的事件，将服务器发来的消息存入消息中心由NetworkManager完成
        

        RegisterCommand(Register, typeof(RegisterCommand));
        RegisterCommand(RefreshRoomList, typeof(RefreshRoomListCommand));
        // 从消息中心监听服务器发来的事件，将服务器发来的消息存入消息中心由NetworkManager完成
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.LogInSuccess, OnLoginSucess);
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.LogInErrorAccountDontExist, OnLoginFailure);
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.LogInErrorPasswordWrong, OnLoginFailure);
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.LogInErrorReLogIn, OnLoginFailure);
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.RegisterSuccess, OnRegisterSuccess);
        MessageCenter.Instance.AddObserver(GameProto.ServerEventCode.RegisterErrorAccountAlreadyExist, OnRegisterFailure);

    }

    protected override void InitializeView() {
        base.InitializeView();
    }

    protected override void InitializeModel() {
        base.InitializeModel();
        RegisterProxy(new UserDataProxy(new UserDataModel()));

        //角色代理注册
        RegisterProxy(new CharactersDataProxy(new CharactersDataModel()));
        //战斗UI代理注册
        RegisterProxy(new BattleUIProxy(new BattleUIModel()));
    }

    private void OnLoginSucess(object data) {
        SendNotification(LoginSuccess);
    }

    private void OnLoginFailure(object data) {
        SendNotification(LoginFailure, data);
    }

    private void OnRegisterSuccess(object data) {
        SendNotification(RegisterSuccess);
    }

    private void OnRegisterFailure(object data) {
        SendNotification(RegisterFailure);
    }
}
