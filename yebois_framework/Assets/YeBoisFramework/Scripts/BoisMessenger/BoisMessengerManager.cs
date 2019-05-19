using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YeBoisFramework.BoisMessaging
{
    public class BoisMessagerManager
    {
        //Singleton Initialization and Setup
        private static BoisMessagerManager boisInstance = null;
        public static BoisMessagerManager Instance
        {
            get
            {
                if (boisInstance == null)
                {
                    boisInstance = new BoisMessagerManager();
                }
                return boisInstance;
            }
            private set { boisInstance = value; }
        }

        private BoisMessagerManager()
        {
            CachedBoisMessengers = new Dictionary<GameObject, List<BoisMessenger>>();
        }

        //Properties and Fields
        private Dictionary<GameObject, List<BoisMessenger>> CachedBoisMessengers;

        //Methods
        public void AddBaseMessenger(GameObject go, BoisMessenger bois)
        {
            if (!CachedBoisMessengers.ContainsKey(go))
            {
                List<BoisMessenger> messengers = new List<BoisMessenger>();
                messengers.Add(bois);
                CachedBoisMessengers.Add(go, messengers);
            }
            else
            {
                CachedBoisMessengers[go].Add(bois);
            }
        }

        public void RemoveBaseMessenger(GameObject go, BoisMessenger bois)
        {
            if (CachedBoisMessengers.ContainsKey(go))
            {
                if (CachedBoisMessengers[go] != null
                || CachedBoisMessengers[go].Count > 0)
                {
                    CachedBoisMessengers[go].Remove(bois);
                }

                //if the list is empty remove the key and value from the dictionary
                if (CachedBoisMessengers[go].Count == 0)
                {
                    CachedBoisMessengers.Remove(go);
                }
            }
        }

        public void SendMessage(string msg, GameObject go, object parameters = null)
        {
            if (CachedBoisMessengers.ContainsKey(go))
            {
                BoisMessenger[] messengers = CachedBoisMessengers[go].ToArray();
                for (int i = 0; i < messengers.Length; i++)
                {
                    messengers[i].ReceiveMessage(msg, parameters);
                }
            }
        }

        public void SendMessageToAll(string msg, object parameters = null)
        {
            foreach (KeyValuePair<GameObject, List<BoisMessenger>> entry in CachedBoisMessengers)
            {
                BoisMessenger[] messengers = entry.Value.ToArray();
                if (messengers != null && messengers.Length > 0)
                {
                    for (int i = 0; i < messengers.Length; i++)
                    {
                        messengers[i].ReceiveMessage(msg, parameters);
                    }
                }
            }
        }
    }
}
