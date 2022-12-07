using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //Clase con los componentes de un sonido
    public string _nameClip;
    public AudioClip _clip;

    [Range(0f, 1f)]
    public float _volume;
    [Range(.1f, 3f)]
    public float _pitch;

    [HideInInspector]
    public AudioSource _source;

    public bool _isLoop;
    public AudioMixerGroup _mixerGroup;

}
