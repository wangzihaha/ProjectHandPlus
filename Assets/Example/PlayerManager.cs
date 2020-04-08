using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example {
    
    // 定义Player的各类型消息ID
    public static class PlayerEvent {
        public enum BasicEvent {
            Start = QMgrID.Player,
            Spawm,
            Destroy,
            Respawn,
            End,
        }

        public enum SkillEvent {
            // 消息ID 会在发送时通过除法转化成 MgrID 
            Start = BasicEvent.End,
            Play,
            Stop,
            End,
        }

        public enum MovementEvent {
            Start = SkillEvent.End,
            Click,
            Grab,
            Release,
            End,
        }
    }

    // 消息体 发送事件若需要参数时定义
    public class PlayerMoveClick : QMsg {
        public string playerId;
        public Vector3 position;
        // 构造函数：定义消息ID，必要部分
        public PlayerMoveClick() : base((int)PlayerEvent.MovementEvent.Click) {
            // 消息初始化
        }
    }

    public class PlayerBasicSpawn : QMsg {
        public string playerId;
        public Vector3 position;
        public PlayerBasicSpawn() : base((int)PlayerEvent.BasicEvent.Spawm) {
        }
    }

    public class PlayerManager : QMgrBehaviour, ISingleton {
        #region QMgrBehaviour Required

        public override int ManagerId {
            get { return QMgrID.Player; }
        }

        #endregion

        #region ISingleton Required

        void ISingleton.OnSingletonInit() {
            // QFramework 语法糖
            "PlayerManger Generated!".LogInfo();
            // Log.I("{0} Generated!", "PlayerManger");
        }

        public static PlayerManager Instance {
            get { return MonoSingletonProperty<PlayerManager>.Instance; }
            //get { return SingletonProperty<PlayerManager>.Instance; }
        }

        #endregion

        private Dictionary<string, Player> players = new Dictionary<string, Player>();

        private void CreatePlayer(string playerId, Vector2 spawnPosition) {
            // user prefab here
            GameObject playerGo = Instantiate(Resources.Load("Player")) as GameObject;
            playerGo.name = playerId;
            Player playerScript = playerGo.AddComponent<Player>();
            playerGo.transform.position = spawnPosition;
            players.Add(playerId, playerScript);

        }

        protected override void ProcessMsg(int eventId, QMsg msg) {
            // 这是向此Manager内事件系统发送消息的操作，在未注册事件时不起作用 
            // base.ProcessMsg(eventId, msg);

            switch (eventId) {
                case (int)PlayerEvent.BasicEvent.Spawm:
                    var playerBasicSpawn = msg as PlayerBasicSpawn;
                    CreatePlayer(playerBasicSpawn.playerId, playerBasicSpawn.position);
                    break;
                case (int)PlayerEvent.MovementEvent.Click:
                    var playerMoveClick = msg as PlayerMoveClick;
                    // 移动所有玩家对象
                    foreach (var pair in players) {
                        pair.Value.OnPlayerClick(playerMoveClick.position);
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
