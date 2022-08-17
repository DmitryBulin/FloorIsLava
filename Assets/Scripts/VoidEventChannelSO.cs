using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for events that dont hold any data (Example: Exit game event)
/// </summary>

[CreateAssetMenu(menuName = "Events / Void Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnEventRaised = delegate { };

    public void RaiseEvent()
    {
        OnEventRaised.Invoke();
    }

}
