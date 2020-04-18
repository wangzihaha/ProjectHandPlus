using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueSync;

/// <summary>
/// 角色数据
/// </summary>
public class CharactersDataModel
{

}

public class CharacterBaseData
{

    ///////////////////////////////////物理信息
    /// <summary>
    /// 角色当前位置（世界坐标系）
    /// </summary>
    public TSVector pos;

    /// <summary>
    /// 角色当前视角朝向（世界坐标系）
    /// </summary>
    public TSVector rot;

    ////////////////////////////////////阵营信息

    //角色阵营：阵营1、阵营2、、、、、、



    //////////////////////////////////属性相关信息

    //角色种族：人类、食尸鬼

    public CharacterAttributes characterAttributes;


    
    //TODO:移动逻辑
    public void Move(TSVector speed, int frameNumber = 1) {

    }

    public void Move(FP speed, int frameNumber = 1) {

    }                                           

    public void MoveFoward(FP speed, int frameNumber = 1) {

    }

    public void MoveFoward(TSVector speed, int frameNumber = 1) {

    }

}
