using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTool : SingletonMonoBehaviour<GameObjectTool>
{
    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    public GameObject RoomShortInfoView;
    public GameObject RoomListPanel;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
