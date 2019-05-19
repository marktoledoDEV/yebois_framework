﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YeBoisFramework.BoisMessaging
{
    public abstract class MonoBois : MonoBehaviour
    {
        private BoisMessenger messenger;

        public GameObject BoisListener;

        protected virtual void Awake()
        {
            if(BoisListener == null)
            {
                BoisListener = gameObject;
            }
            messenger = new BoisMessenger(BoisListener);
        }

        public void CacheMethod(string msg, BoisMessenger.BoisMethod method)
        {
            messenger.CacheMethod(msg, method);
        }

        public void Call(string msg, GameObject targetGO, object parameters = null)
        {
            messenger.Call(msg, targetGO, parameters);
        }

        public void Broadcast(string msg, object parameters = null)
        {
            messenger.Broadcast(msg, parameters);
        }
    }
}
