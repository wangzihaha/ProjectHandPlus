using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example {
    public class Mgr2Mgr : QMonoBehaviour {

        #region QMonoBehaviour Required

        public override IManager Manager {
            get { return UIManager.Instance; }
        }

        #endregion

        // Update is called once per frame
        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                SendMsg(new PlayerBasicSpawn() {
                    playerId = "Player" + Time.time,
                    position = Camera.main.ScreenToWorldPoint(Input.mousePosition),
                });
            }

            if(Input.GetMouseButtonDown(1)) {
                SendMsg(new PlayerMoveClick() {
                    position = Camera.main.ScreenToWorldPoint(Input.mousePosition),
                });
            }
        }

        
    }
}
