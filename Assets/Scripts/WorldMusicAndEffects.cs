using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMusicAndEffects : MonoBehaviour {

    public AudioClip ambiance;
    public AudioClip firstPiano;
    public AudioClip secondPiano;
    public AudioClip thirdPiano;
    public AudioClip fourthPiano;

    public AudioSource worldAudioSource;

    public int pianoNumber;

    // Use this for initialization
    void Start () {

        worldAudioSource.clip = ambiance;
        worldAudioSource.Play();

        InvokeRepeating("PlayPiano", 1.0f, 7.0f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayPiano()
    {
        
        // play random piano hit 
        pianoNumber = Random.Range(1, 5);

        if (pianoNumber == 1)
        {
            worldAudioSource.PlayOneShot(firstPiano, .3f);
        }
        else if (pianoNumber == 2)
        {
            worldAudioSource.PlayOneShot(secondPiano, .3f);
        }
        else if (pianoNumber == 3)
        {
            worldAudioSource.PlayOneShot(thirdPiano, .3f);
        }
        else
        {
            worldAudioSource.PlayOneShot(fourthPiano, .3f);
        }

    }
}
