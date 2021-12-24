using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YeBoisFramework.SaveLoad
{
    public interface ISaveLoadEntity
    {
        string SaveLoadName();
        void OnSave();
        void OnLoad();
    }
}
