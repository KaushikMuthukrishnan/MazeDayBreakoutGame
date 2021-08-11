using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AmbientAudio : MonoBehaviour
{
    public PlayableDirector director;
    public AudioSource StartingAmbientMusic;
    public AudioClip FightMusic;

    int count;

    public bool AudioAbleToPlay1;

    private void Start()
    {
        director = GameObject.Find("1st Enemy Load Trigger").GetComponent<PlayableDirector>();
        StartingAmbientMusic = GetComponent<AudioSource>();
        StartingAmbientMusic.volume = 0.25f;
        AudioAbleToPlay1 = true;
        StartingAmbientMusic.Play();
    }

    private void Update()
    {
        if (director.state == PlayState.Playing)
        {
            
            if (AudioAbleToPlay1)
            {
                StartingAmbientMusic.Stop();
                StartingAmbientMusic.clip = FightMusic;
                StartingAmbientMusic.Play();
                AudioAbleToPlay1 = false;
            }
        }
    }
}
