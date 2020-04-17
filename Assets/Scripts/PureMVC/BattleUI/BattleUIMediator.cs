using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class BattleUIMediator : Mediator
{
    public new const string NAME = "BattleUIMediator";
    //private LoginPanelView view;
    private readonly BattleUIProxy battleUIProxy;

    public BattleUIMediator(object viewComponent) : base(NAME, viewComponent) {

        //监听技能（道具）按钮
        for (int i = 0; i < ((BattleUIView)ViewComponent).SkillBTs.Count; i++) {
            int a = i;
            ((BattleUIView)ViewComponent).SkillBTs[0].onClick.AddListener(delegate() {
                OnClickSkillBT(a);
            });
        }

        ((BattleUIView)ViewComponent).AddListener(OnDragTouch);

        battleUIProxy = Facade.RetrieveProxy(BattleUIProxy.NAME) as BattleUIProxy;
    }

    private void OnClickSkillBT(int id) {
        //FrameDataModel
        //TODO::向服务器发送技能操作
    }

    private void OnDragTouch() {
        //TODO::向服务器发送移动操作
        
    }

    public override IList<string> ListNotificationInterests() {
        return new List<string>() { 
            //MyFacade.LoginSuccess, 
            //MyFacade.LoginFailure
        };
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            //case MyFacade.LoginSuccess:
            //    ((LoginPanelView)ViewComponent).messageText.text = "succeed";
            //    break;
            default:
                break;
        }
    }
}
