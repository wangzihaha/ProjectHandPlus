using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class NetManager : ISingleton
{
    void ISingleton.OnSingletonInit() {
        Debug.Log("Network Manager Generated!");
    }

    public static NetManager Instance {
        get { return SingletonProperty<NetManager>.Instance; }
    }

    private NetManager() {

    }

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
