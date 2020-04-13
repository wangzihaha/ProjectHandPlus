using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class UserDataProxy : Proxy
{
    public new const string NAME = "UserData";
    
    public UserDataProxy(object data) : base(NAME, data) {

    }

    public void SetProperty(string email, string password) {
        ((UserDataModel)Data).email = email;
        ((UserDataModel)Data).password = password;
        Debug.Log("UserDataProxy: " + ((UserDataModel)Data).email + ", " + ((UserDataModel)Data).password);
    }

}
