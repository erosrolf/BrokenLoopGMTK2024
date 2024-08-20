using BrokenLoop.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundAudioClip
    {
        public string name;
        public AudioClip audioClip;
    }
    public SoundAudioClip[] sound;
    public AudioMixer audioMixer;
    public AudioSource audioMusic;
    public AudioSource audioEffect;
    #region Singleton
    public static SoundManager _instance;
    public static SoundManager Instance 
    { 
        get 
        { 
            if(_instance == null )
            {
                _instance = FindFirstObjectByType<SoundManager>();
                if(_instance == null)
                {
                    _instance = new SoundManager();
                }
            }
            return _instance; 
        }
    }
    #endregion
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            Debug.LogError("You trying to create a second singletone!");
            return;
        }

        _instance = this;
    }


    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume)*20f);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20f);
    }

    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("Effect", Mathf.Log10(volume) * 20f);
    }

    public void PlayMusic(string name)
    {
        AudioClip clip = sound.FirstOrDefault(x => x.name == name).audioClip;
        if(clip != null)
        {
            audioMusic.PlayOneShot(clip);
            Debug.Log("Yep");
        }

    }
    public void PlayEffect(string name)
    {
        AudioClip clip = sound.FirstOrDefault(x => x.name == name).audioClip;
        if (clip != null)
        {
            Debug.Log("Nope");
            audioEffect.PlayOneShot(clip);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayEffect("GameStart");
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            PlayEffect("BuildTower");
        }
    }

}
