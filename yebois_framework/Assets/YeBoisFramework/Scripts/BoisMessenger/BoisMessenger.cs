using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YeBoisFramework.Utility;

namespace YeBoisFramework.BoisMessaging
{
    public class BoisMessenger
    {
        public delegate void BoisMethod(object o = null);

        private BoisMessagerManager mBoisMessagerManager;
        private IBoisListener mCachedBoisListener;
        private Dictionary<string, BoisMethod> BoisMessageHandler = new Dictionary<string, BoisMethod>();

        public BoisMessenger(IBoisListener listener)
        {
            mCachedBoisListener = listener;
            mBoisMessagerManager = ServiceLocator.Instance.GetService<BoisMessagerManager>();
            mBoisMessagerManager.AddBaseMessenger(mCachedBoisListener, this);
        }

        ~BoisMessenger()
        {
            mBoisMessagerManager.RemoveBaseMessenger(mCachedBoisListener, this);
            mCachedBoisListener = null;
            BoisMessageHandler = null;
        }

        public void CacheMethod(string msg, BoisMethod action)
        {
            if (BoisMessageHandler.ContainsKey(msg))
            {
                BoisMessageHandler[msg] += action;
            }
            else
            {
                BoisMessageHandler.Add(msg, action);
            }
        }

        public void Call(string msg, IBoisListener listener, object parameters = null)
        {
            mBoisMessagerManager.SendMessage(msg, listener, parameters);
        }

        public void Call(string msg, GameObject targetGO, object parameters = null)
        {
            mBoisMessagerManager.SendMessage(msg, targetGO, parameters);
        }

        public void Broadcast(string msg, object parameters = null)
        {
            mBoisMessagerManager.SendMessageToAll(msg, parameters);
        }

        public void ReceiveMessage(string msg, object parameters = null)
        {
            if (BoisMessageHandler.ContainsKey(msg))
            {
                if (BoisMessageHandler[msg] != null)
                {
                    BoisMessageHandler[msg](parameters);
                }
            }
        }
    }
}
