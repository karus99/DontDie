using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    AudioSource soundEffect;
    bool fadeOut = false;
    // Use this for initialization
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }

    public void FadeAndStopAllSounds()
    {
        fadeOut = true;

    }

    public void ResetAll()
    {
        soundEffect.volume = 1;
        fadeOut = false;

    }

    

    // Update is called once per frame
    void Update()
    {
        if(soundEffect.volume>0 && fadeOut){

            soundEffect.volume -= 1 * Time.deltaTime;
        }
    }
}
