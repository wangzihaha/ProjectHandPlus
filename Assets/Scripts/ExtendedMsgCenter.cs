using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QFramework.Example;

namespace QFramework {
    public partial class QMsgCenter {
        partial void ForwardMsg(QMsg tmpMsg) {
            switch (tmpMsg.ManagerID) {
                case QMgrID.Player:
                    // Manager的SendMsg方法如果发现是自己管理的事件会自己处理
                    PlayerManager.Instance.SendMsg(tmpMsg);
                    break;
            }
        }
    }
}
