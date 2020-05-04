using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button buttonEventParameterless;
    public Button buttonEventParameters;
    public Button buttonEventFull;

    private AnalyticsManager _manager = new AnalyticsManager();

    void Start()
    {
        buttonEventParameterless.interactable = false;
        buttonEventParameters.interactable = false;
        buttonEventFull.interactable = false;

        _manager.Initialize(OnServicesInitialized);
    }

    private void OnServicesInitialized()
    {
        buttonEventParameterless.interactable = true;
        buttonEventParameters.interactable = true;
        buttonEventFull.interactable = true;
    }

    public void TriggerEventParameterless()
    {
        _manager.SendCustomEvent("Event_parameterless");
    }

    public void TriggerEventParams()
    {
        Dictionary<string, object> eventParams = new Dictionary<string, object>();
        eventParams["valeur"] = 42;
        _manager.SendCustomEvent("Event_params", eventParams);
    }

    public void TriggerEventFull()
    {
        Dictionary<string, object> eventParams = new Dictionary<string, object>();
        eventParams["nom"] = "toto";
        eventParams["value"] = 12;

        _manager.SendCustomEvent("Event_full", eventParams);
    }
}
