using UnityEngine;
using UnityEngine.Events;

public class InteractionUIEventListener : MonoBehaviour
{
    [SerializeField] private InteractionUIEventChannelSO _channel = default;

    public UnityEvent<bool> OnEventRaised;

    private void OnEnable()
    {
        if (_channel != null)
            _channel.OnEventRaised += Respond;
    }

    private void OnDisable()
    {
        if (_channel != null)
            _channel.OnEventRaised -= Respond;
    }

    private void Respond(bool state)
    {
        OnEventRaised?.Invoke(state);
    }

}
