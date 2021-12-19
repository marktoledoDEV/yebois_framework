using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YeBoisFramework.BoisMessaging;

namespace YeBoisFramework.Utility
{
    //This is responsible for initializing all the services we need
    public class DependencyContainer : MonoBehaviour
    {
        private void Awake() 
        {
            ServiceLocator.Instance.AddService(new BoisMessagerManager());
        }
    }
}
