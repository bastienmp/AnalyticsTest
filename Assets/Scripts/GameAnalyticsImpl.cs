using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Unity;
using UnityEngine;
using GameAnalyticsSDK;

public class GameAnalyticsImpl : IAnalytics
{
    public void Initialize(Action callback)
    {
        GameAnalytics.Initialize();
        callback();
    }

    public void SendCustomEvent(string eventName, Dictionary<string, object> eventParameters = null, float? computeValue = null)
    {
        //Game Analytics doesnt let us set extra parameters, the only thing we can set are the name and value, and name can only have around max 10k values, so we shouldnt put any number value in it 
        // -https://gameanalytics.com/docs/item/unity-sdk#design
        // -https://gameanalytics.com/docs/item/design-events
        if (computeValue == null)
            GameAnalytics.NewDesignEvent(eventName);
        else
            GameAnalytics.NewDesignEvent(eventName, computeValue ?? 0);
    }
}