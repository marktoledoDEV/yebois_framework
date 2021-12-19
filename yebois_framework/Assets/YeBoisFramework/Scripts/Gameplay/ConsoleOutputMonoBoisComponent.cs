using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YeBoisFramework.BoisMessaging
{
    public class ConsoleOutputMonoBoisComponent : AbstractMonoBoisComponent
    {
        [SerializeField]
        private string mBoisMsg;

        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            CacheMethod(mBoisMsg, outputToConsole);
        }

        void outputToConsole(object o)
        {
            if (o is string)
            {
                string msg = o as string;
                Debug.Log(msg);
            }
            else
            {
                Debug.LogError("o is not a string type");
            }
        }
    }
}
