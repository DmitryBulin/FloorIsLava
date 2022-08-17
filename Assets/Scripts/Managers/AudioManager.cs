using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This class handles all of sound requests from any objects via audio channels
/// </summary>

public class AudioManager : MonoBehaviour
{
    [Header("SoundEmitters pool")]
    [SerializeField] private SoundEmitter _soundEmitterPrefab;
    [SerializeField] private int _initialSize = 10;

    [Header("Listening on channels")]
    [SerializeField] private AudioCueChannelSO _musicEventChannel = default;
    [SerializeField] private AudioCueChannelSO _SFXEventChannel = default;
    
    private List<SoundEmitter> _soundEmitterList;
    private int _currentEmitterIndex;

    private void Awake()
    {
        InstantiateSoundEmitters();
    }
    
    private void OnEnable()
    {
        RegisterChannel(_musicEventChannel);
        RegisterChannel(_SFXEventChannel);
    }

    private void OnDisable()
    {
        UnregisterChannel(_musicEventChannel);
        UnregisterChannel(_SFXEventChannel);
    }

    private void RegisterChannel(AudioCueChannelSO audioCueChannel)
    {
        audioCueChannel.OnAudioRequested += PlayAudioCue;
    }

    private void UnregisterChannel(AudioCueChannelSO audioCueChannel)
    {
        audioCueChannel.OnAudioRequested -= PlayAudioCue;
    }

    public void PlayAudioCue(AudioCueSO audioCue)
    {
        _soundEmitterList[_currentEmitterIndex].PlayAudioClip(audioCue.audioClip);
        _currentEmitterIndex = (_currentEmitterIndex + 1) % _soundEmitterList.Capacity;
    }

    private void InstantiateSoundEmitters()
    {
        _soundEmitterList = new List<SoundEmitter>();
        _currentEmitterIndex = 0;
        for (int i = 0; i < _initialSize; ++i)
        {
            _soundEmitterList.Add(Instantiate(_soundEmitterPrefab, transform));
        }
    }
}
