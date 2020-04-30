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
        buttonEventParameterless.onClick.AddListener(() => {
            _manager.SendCustomEvent("Event_parameterless");
        });

        buttonEventParameters.interactable = false;
        buttonEventParameters.onClick.AddListener(() => {
            Dictionary<string, object> eventParams = new Dictionary<string, object>();
            eventParams["valeur"] = 42;
            _manager.SendCustomEvent("Event_params", eventParams);
        });

        buttonEventFull.interactable = false;
        buttonEventFull.onClick.AddListener(() => {
            Dictionary<string, object> eventParams = new Dictionary<string, object>();
            eventParams["nom"] = "toto";
            eventParams["value"] = 12;

            _manager.SendCustomEvent("Event_full", eventParams);
        });

        _manager.Initialize(OnServicesInitialized);
    }

    private void OnServicesInitialized()
    {
        buttonEventParameterless.interactable = true;
        buttonEventParameters.interactable = true;
        buttonEventFull.interactable = true;
    }
}
