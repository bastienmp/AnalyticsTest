using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Unity;
using UnityEngine;

public class GameAnalytics : IAnalytics
{
    public void Initialize(Action callback)
    {
        callback();
    }

    public void SendEvent(string eventName, Dictionary<string, object> eventParameters)
    {
        Debug.Log("Send event from gameanlytics");
    }
}
