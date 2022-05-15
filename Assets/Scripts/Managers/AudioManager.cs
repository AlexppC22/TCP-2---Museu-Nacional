using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Clips
{
    click,
    positiveFeedback,
    negativeFeedback,
    pyramidRotate
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    Clips clips;
    public AudioSource audioSource;
    public AudioClip[] sounds;
    private void Awake() 
    {
        instance = this;
    }

    public void PlaySound(int play)
    {
        switch((Clips)play)
        {
            case Clips.click:
                audioSource.PlayOneShot(sounds[0]);
            break;
            case Clips.positiveFeedback:
                audioSource.PlayOneShot(sounds[1]);
            break;
            case Clips.negativeFeedback:
                audioSource.PlayOneShot(sounds[2]);
            break;
            case Clips.pyramidRotate:
                audioSource.PlayOneShot(sounds[3]);
                break;


            default:
            Debug.Log("Mudo");
            break;       
        }
    }
}
