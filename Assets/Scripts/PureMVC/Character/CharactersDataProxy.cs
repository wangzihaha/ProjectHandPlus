using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;


/// <summary>
/// 所有角色的管理代理
/// </summary>
public class CharactersDataProxy : Proxy
{
    public new const string NAME = "CharactersData";
    
    public CharactersDataProxy(object data) : base(NAME, data) {

    }


    /// <summary>
    /// 更新一帧所有角色的数据
    /// </summary>
    public void FrameUpdata(FrameDataModel message) {





        //角色逻辑更新完毕，发送通知更新角色视图
        SendNotification(MyFacade.CharacterViewUpdata);
    }

}
