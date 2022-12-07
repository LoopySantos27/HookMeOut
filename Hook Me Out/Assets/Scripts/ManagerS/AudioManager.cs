using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Arreglo de clases de audios
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //Agregar un audiolistener por cada audio que haya
        foreach (Sound s in sounds)
        {
            //Recibir el audioSource del componente
            s._source = gameObject.AddComponent<AudioSource>();
            //Agarrar los valores de la clase Sound
            s._source.clip = s._clip;

            s._source.volume = s._volume; 
            s._source.pitch = s._pitch;
            s._source.loop = s._isLoop;
            s._source.outputAudioMixerGroup = s._mixerGroup;
        }
    }

    public void Play (string nameClip)
    {
        //Buscar en la lista de sonidos el clip que concuerde con el que se pidio
        Sound s = Array.Find(sounds, sound => sound._nameClip == nameClip);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "Not found!");
            return;
        }
        s._source.Play();
    }

    public void StopMusic(string nameClip)
    {
        //Buscar en la lista de sonidos el clip que concuerde con el que se pidio
        Sound s = Array.Find(sounds, sound => sound._nameClip == nameClip);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "Not found!");
            return;
        }
        s._source.Stop();
    }
}
