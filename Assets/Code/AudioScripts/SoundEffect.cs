using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private bool shouldVoiceSteal = true;
    [SerializeField] private bool shouldRandomize;
    [SerializeField] [Range(0.0f, 0.5f)] private float pitchDeviation;
    [SerializeField] [Range(0.0f, 0.5f)] private float volumeDeviation;

    private readonly List<AudioSource> _audioSources = new List<AudioSource>();

    private int _playIndex;

    void Awake()
    {
        _audioSources.Add(GetComponent<AudioSource>());
    }

    private void OnEnable()
    {
        _playIndex = 0;
    }

    public void Play()
    {
        var tSource = VoiceStealCheck();
        var tClip = shouldRandomize ? audioClips[Random.Range(0, audioClips.Length - 1)] : audioClips[_playIndex];
        
        
        tSource.volume = Deviation.Deviate(tSource.volume, volumeDeviation);
        tSource.pitch = Deviation.Deviate(tSource.pitch, pitchDeviation);

        tSource.clip = tClip;
        tSource.Play();
        _playIndex = _playIndex == audioClips.Length ? _playIndex = 0 : + 1;
    }

    private AudioSource VoiceStealCheck()
    {
        if (shouldVoiceSteal) return _audioSources[0];
        foreach (var source in _audioSources.Where(source => !source.isPlaying))
        {
            return source;
        }
        return CopyComponent.Copy(_audioSources[0], this.gameObject);
    }
}
