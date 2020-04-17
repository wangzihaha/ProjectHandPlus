using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Protobuf;
using GameProto;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class BattleUICommand : SimpleCommand
{
   public override void Execute(INotification notification) {
        CharactersDataProxy proxy = Facade.RetrieveProxy(CharactersDataProxy.NAME) as CharactersDataProxy;
        FrameDataModel message = (FrameDataModel)notification.Body;

        proxy.FrameUpdata(message);
   }
}
