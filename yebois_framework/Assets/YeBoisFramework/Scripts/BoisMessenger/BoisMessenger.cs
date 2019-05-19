using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YeBoisFramework.BoisMessaging
{
    public class BoisMessenger
    {
        public delegate void BoisMethod(object o = null);


        private GameObject cachedGameObject;
        private Dictionary<string, BoisMethod> BoisMessageHandler = new Dictionary<string, BoisMethod>();

        public BoisMessenger(GameObject go)
        {
            cachedGameObject = go;
            BoisMessagerManager.Instance.AddBaseMessenger(cachedGameObject, this);
        }

        ~BoisMessenger()
        {
            BoisMessagerManager.Instance.RemoveBaseMessenger(cachedGameObject, this);
            cachedGameObject = null;
            BoisMessageHandler = null;
        }

        public void CacheMethod(string msg, BoisMethod action)
        {
            if(BoisMessageHandler.ContainsKey(msg))
            {
                BoisMessageHandler[msg] += action;
            }
            else
            {
                BoisMessageHandler.Add(msg, action);
            }
        }

        public void Call(string msg, GameObject targetGO, object parameters = null)
        {
            BoisMessagerManager.Instance.SendMessage(msg, targetGO, parameters);
        }

        public void Broadcast(string msg, object parameters = null)
        {
            BoisMessagerManager.Instance.SendMessageToAll(msg, parameters);
        }

        public void ReceiveMessage(string msg, object parameters = null)
        {
            if(BoisMessageHandler.ContainsKey(msg))
            {
                if(BoisMessageHandler[msg] != null)
                {
                    BoisMessageHandler[msg](parameters);
                }
            }
        }
    }
}
