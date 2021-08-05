using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TriggerEnemies : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            var playable = GetComponent<PlayableDirector>();
            playable.Play(playable.playableAsset);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
