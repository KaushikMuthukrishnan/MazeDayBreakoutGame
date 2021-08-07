using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBobbingControls : MonoBehaviour
{
    public AudioSource bob1;

    public bool bob1AbleToPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        bob1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bob1AbleToPlay)
        {
            bob1.Stop();
            bob1.Play();
            
            bob1AbleToPlay = false;
        }
    }
}
