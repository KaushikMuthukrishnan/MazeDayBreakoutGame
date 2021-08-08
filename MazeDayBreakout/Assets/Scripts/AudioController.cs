using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bobbingNoise;
    public bool audioAbleToPlay;

    // Start is called before the first frame update
    void Start()
    {
        bobbingNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioAbleToPlay)
        {
            bobbingNoise.Play();
        }
    }
}
