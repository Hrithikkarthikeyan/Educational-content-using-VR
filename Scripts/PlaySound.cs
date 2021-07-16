using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySound : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public AudioClip SoundToPlay2;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    public GameObject pauseMenu;
    public AudioMixer mixer;
    public PauseApp Pause;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        if(pauseMenu.active){
            //audio.mute=true;
            audio.Pause();
        }
        else{
            //audio.mute=false;
            audio.UnPause();
        }
    }
    void OnTriggerEnter()
    {
        if(!alreadyPlayed ){
            audio.PlayOneShot(SoundToPlay, Volume);
            audio.pitch = Pause.speed;
            mixer.SetFloat("SpeedParam", 1/Pause.speed);
            alreadyPlayed = true;
            Invoke("DoSomething", 2);
        }
        
    }

    void DoSomething(){
        audio.Stop();
        audio.PlayOneShot(SoundToPlay2, Volume);
        audio.pitch = Pause.speed;
        mixer.SetFloat("SpeedParam", 1/Pause.speed);
        Invoke("DoSomething2", 3);
    }

    void DoSomething2(){
    	audio.Stop();
    }

}
