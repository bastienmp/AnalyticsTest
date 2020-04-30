using System;
using System.Collections.Generic;

interface IAnalytics
{
    /// <summary>
    /// Initialize the service
    /// </summary>
    /// <param name="callback">Called when the service is ready</param>
    void Initialize(Action callback);

    /// <summary>
    /// Send a custom event
    /// </summary>
    /// <param name="eventName">Name of the event</param>
    /// <param name="eventParameters">Parameters of the event (not fully supported by all services)</param>
    /// <param name="computeValue">Amount to be aggregated into all events of this eventName, and it will be reported as cumulative and/or average value of this amount</param>
    void SendCustomEvent(string eventName, Dictionary<string, object> eventParameters = null, float? computeValue = null);
}
