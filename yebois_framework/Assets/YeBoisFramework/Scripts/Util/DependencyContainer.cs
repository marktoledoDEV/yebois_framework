using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YeBoisFramework.BoisMessaging;
using YeBoisFramework.SaveLoad;

namespace YeBoisFramework.Utility
{
    //This is responsible for initializing all non MonoBehaviour services.
    public class DependencyContainer : MonoBehaviour
    {
        private void Awake() 
        {
            ServiceLocator.Instance.AddService(new BoisMessagerManager());
            ServiceLocator.Instance.AddService(new SaveLoadService());
        }
    }
}
