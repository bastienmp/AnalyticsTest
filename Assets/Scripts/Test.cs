using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            _manager?.SendEvent("Event_parameterless");
        });

        buttonEventParameters.interactable = false;
        buttonEventParameters.onClick.AddListener(() => {
            Dictionary<string, object> eventParams = new Dictionary<string, object>();
            eventParams["valeur"] = 42;

            _manager?.SendEvent("Event_params", eventParams);
        });

        buttonEventFull.interactable = false;
        buttonEventFull.onClick.AddListener(() => {
            Dictionary<string, object> eventParams = new Dictionary<string, object>();
            eventParams["value"] = 12;
            eventParams["nom"] = "toto";

            _manager?.SendEvent("Event_full", eventParams);
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
