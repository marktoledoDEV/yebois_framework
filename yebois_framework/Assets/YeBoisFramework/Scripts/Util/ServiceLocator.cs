using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YeBoisFramework.Utility
{
    public interface IService{ }

    //This is responsible for providing the appropriate services different systems need to function in a conveniant and global way
    public class ServiceLocator
    {
        private static ServiceLocator serviceLocatorInstance = null;
        public static ServiceLocator Instance
        {
            get
            {
                if (serviceLocatorInstance == null)
                {
                    serviceLocatorInstance = new ServiceLocator();
                }
                return serviceLocatorInstance;
            }
            private set { serviceLocatorInstance = value; }
        }

        private List<IService> mServices = new List<IService>();

        private ServiceLocator() { }

        public void AddService<T>(T service) where T : IService
        {
            if(mServices.Contains(service))
            {
                Debug.LogWarning(service + "already has been added to ServiceLocator");
                return;
            }

            mServices.Add(service);
        }

        public void RemoveService<T>(T service) where T : IService
        {
            if(!mServices.Contains(service))
            {
                Debug.LogWarning("ServiceLocator does not contain: " + service);
                return;
            }

            mServices.Remove(service);
        }

        
        public T GetService<T>() where T : IService
        {
            foreach(IService service in mServices)
            {
                if(service is T)
                {
                    return (T)service;
                }
            }
            Debug.LogError("Service was not found!!");
            return default(T);
        }
        
    }
}
