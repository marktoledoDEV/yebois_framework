using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YeBoisFramework.BoisMessaging
{
    public class ConsoleInputMonoBoisComponent : AbstractMonoBoisComponent
    {
        [SerializeField]
        private string mBoisMsg;

        [SerializeField]
        private bool mBroadcastMsg;

        [SerializeField]
        private GameObject mGOTarget;

        [SerializeField]
        private string mConsoleMsg;
        void Start()
        {
            if (mBroadcastMsg)
            {
                Broadcast(mBoisMsg, mConsoleMsg);
            }
            else
            {
                Call(mBoisMsg, mGOTarget, mConsoleMsg);
            }
        }
    }
}
