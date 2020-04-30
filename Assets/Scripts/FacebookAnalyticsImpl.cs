using System;
using System.Collections.Generic;
using Facebook.Unity;

public class FacebookAnalyticsImpl : IAnalytics
{
    public void Initialize(Action callback)
    {
        FB.Init(() => {
            callback();
        });
    }

    public void SendCustomEvent(string eventName, Dictionary<string, object> eventParameters = null, float? computeValue = null)
    {
        if (FB.IsInitialized)
            FB.LogAppEvent(eventName, computeValue, eventParameters);
    }
}
