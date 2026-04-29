using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class audioCapturer : MonoBehaviour
{
    public AudioSource Source;
    AudioClip clip;
    public void Record()
    {
        clip = Microphone.Start(null, false, 3599, AudioSettings.outputSampleRate);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Hand"))
        {
            Record();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Hand"))
        { 
            Microphone.End(null);
        }

        PlaySound();
    }


    public void PlaySound()
    {
        Source.clip = clip;
        Source.Play();
    }
}
