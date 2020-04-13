using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : Singleton<NetworkManager>
{
    public void Send(object data) {
        Process(data);
    }

    private void Process(object data) {
        Debug.Log(data.ToString());
        if(data.ToString().Length > 1) {
            MyFacade.GetInstance().SendNotification(MyFacade.LoginSucceed);
        } else {
            MyFacade.GetInstance().SendNotification(MyFacade.LoginFailed);
        }
    }
}
