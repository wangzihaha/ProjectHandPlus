using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example {
    public class NonMgr2Mgr : MonoBehaviour {
        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                PlayerManager.Instance.SendMsg(new PlayerBasicSpawn() {
                    playerId = "Player" + Time.time,
                    position = Camera.main.ScreenToWorldPoint(Input.mousePosition),
                });
            }

            if (Input.GetMouseButtonDown(1)) {
                PlayerManager.Instance.SendMsg(new PlayerMoveClick() {
                    position = Camera.main.ScreenToWorldPoint(Input.mousePosition),
                });
            }
        }
    }
}

