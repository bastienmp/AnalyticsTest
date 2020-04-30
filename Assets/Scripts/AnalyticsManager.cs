using System;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsManager
{
    public enum Service
    {
        FACEBOOK = 0,
        GAME_ANALYTICS,
    }

    private enum ServiceState
    {
        CREATED = 0,
        INITIALIZED
    }

    private Dictionary<Service, IAnalytics> _services = new Dictionary<Service, IAnalytics>();
    private Dictionary<Service, ServiceState> _servicesState = new Dictionary<Service, ServiceState>();
    private Action _initCallback = null;

    /// <summary>
    /// Initialize the services
    /// </summary>
    /// <param name="callback">Callback called when the services are initialized</param>
    /// <param name="services">Array of services to Initialize, if null or empty, all the services available will be initialize</param>
    public void Initialize(Action callback, Service[] services = null)
    {
        _initCallback = callback;

        if (services == null || services.Length == 0)
            services = (Service[])Enum.GetValues(typeof(Service));

        for (int i = 0; i < services.Length; i++)
        {
            switch (services[i])
            {
                case Service.FACEBOOK:
                    _services.Add(services[i], new FacebookAnalyticsImpl());
                    break;
                case Service.GAME_ANALYTICS:
                    _services.Add(services[i], new GameAnalyticsImpl());
                    break;
                default:
                    Debug.LogError("AnalyticsManager::Initialize: Missing initialize code for " + services[i] + ".");
                    break;
            }
            _servicesState.Add(services[i], ServiceState.CREATED);
        }

        foreach (KeyValuePair<Service, IAnalytics> serviceIte in _services)
        {
            serviceIte.Value.Initialize(() => { OnInitialized(serviceIte.Key); });
        }
    }

    private void OnInitialized(Service serviceInitialized)
    {
        _servicesState[serviceInitialized] = ServiceState.INITIALIZED;

        //check if all created service are initialized
        foreach (KeyValuePair<Service, ServiceState> serviceIte in _servicesState)
        {
            if (serviceIte.Value != ServiceState.INITIALIZED)
                return;
        }
        //if we are here, all the services has been initialized
        _initCallback?.Invoke();
    }

    /// <summary>
    /// Send an event to the designed analytics services.
    /// </summary>
    /// <param name="eventName">Name of the event</param>
    /// <param name="eventParameters">Parameters of the event (not fully supported by all services)</param>
    /// <param name="computeValue">Amount to be aggregated into all events of this eventName, and it will be reported as cumulative and/or average value of this amount</param>
    /// <param name="services">The services to send the event to, if null or empty, all the services available will be initialize</param>
    public void SendCustomEvent(string eventName, Dictionary<string, object> eventParameters = null, float? computeValue = null, Service[] services = null)
    {
        if (services == null || services.Length == 0)
            services = (Service[])Enum.GetValues(typeof(Service));

        for (int i = 0; i < services.Length; i++)
        {
            _services[services[i]].SendCustomEvent(eventName, eventParameters, computeValue);
        }
    }
}
