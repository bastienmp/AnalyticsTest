using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

interface IAnalytics
{
    void Initialize(Action callback);
    void SendEvent(string eventName, Dictionary<string, object> eventParameters = null);
}
