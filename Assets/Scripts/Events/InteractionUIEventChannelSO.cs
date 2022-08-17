using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// This class is used for Events to toggle the interaction UI.
/// Example: Dispaly or hide the interaction UI via a bool
/// </summary>

[CreateAssetMenu(menuName = "Events / Interaction UI Event Channel")]
public class InteractionUIEventChannelSO : ScriptableObject
{
    public UnityAction<bool> OnEventRaised;
    public void RaiseEvent(bool state)
    {
        OnEventRaised?.Invoke(state);
    }
}
