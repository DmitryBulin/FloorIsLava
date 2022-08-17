using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class implements event channel for audio requests. It can then be processed by Audio Manager
/// </summary>

[CreateAssetMenu(menuName = "Events / Audio Channel")]
public class AudioCueChannelSO : ScriptableObject
{
    public UnityAction<AudioCueSO> OnAudioRequested = delegate { };

    public void RequestAudio(AudioCueSO audioCue)
    {
        OnAudioRequested.Invoke(audioCue);
    }

}
