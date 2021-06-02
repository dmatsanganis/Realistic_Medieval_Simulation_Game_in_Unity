using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] audioSources;

	//void method which manage sound effects
    public void PlaySound(string name)
    {
        AudioSource audio = Array.Find(audioSources, audioSource => audioSource.clip.name == name);
        if (audio == null)
        {
            return;
        }
        audio.Play();
    }
}
