using UnityEngine.Audio;
using UnityEngine;
using System;



[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;

    [Range(0f,1f)]    
    public float Volume;
    [Range(.1f,3)]
    public float Pitch;
    
    
    [HideInInspector]
    public AudioSource source;



}