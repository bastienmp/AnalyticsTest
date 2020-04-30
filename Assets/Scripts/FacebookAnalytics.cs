using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Unity;

public class FacebookAnalytics : IAnalytics
{
    public void Initialize(Action callback)
    {
        FB.Init(() => {
            callback();
        });
    }

    public void SendEvent(string eventName, Dictionary<string, object> eventParameters)
    {
        FB.LogAppEvent(eventName, null, eventParameters);
    }
}
