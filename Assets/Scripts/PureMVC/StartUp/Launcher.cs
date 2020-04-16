﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public string ip;
    public int port;
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.CreateInstance();
        NetworkManager.Instance.Connect(ip, port);
        MyFacade.GetInstance().SendNotification(MyFacade.StartUp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}