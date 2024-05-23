using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;


   void Awake(){
    foreach(Sound s in sounds){

        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.Clip;

        s.source.volume = s.Volume;
        s.source.pitch = s.Pitch;
        s.source.loop = s.Loop;
    }
   }
    // Update is called once per frame

    public void Play (string Name){
        
        Sound s = Array.Find(sounds,sound => sound.Name == Name);
        s.source.Play();
    }
    public void Stop (string Name){
                Sound s = Array.Find(sounds,sound => sound.Name == Name);
        s.source.Stop();
    }
    public void StopAll(){
        foreach (Sound s in sounds){
            s.source.Stop();
        }
    }

}
