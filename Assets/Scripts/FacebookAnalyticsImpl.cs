using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Unity;

public class FacebookAnalyticsImpl : IAnalytics
{
    public void Initialize(Action callback)
    {
        FB.Init(() => {
            FB.ActivateApp();
            callback();
        });
    }

    public void SendCustomEvent(string eventName, Dictionary<string, object> eventParameters = null, float? computeValue = null)
    {
        FB.LogAppEvent(eventName, computeValue, eventParameters);
    }
}
