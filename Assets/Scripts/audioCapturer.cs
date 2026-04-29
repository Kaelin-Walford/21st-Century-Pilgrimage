using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

using UnityEngine.InputSystem;

public class audioCapturer : MonoBehaviour
{
    public AudioSource Source;
    AudioClip clip;
    public InputActionProperty recordButton;
    public InputActionProperty playButton;
    public XRGrabInteractable grabInteractable;

    public static int grabbed = 0;

    void Update()
    {
        if (grabbed > 0)
        {
            if (recordButton.action.WasPressedThisFrame() == true)
            {
                Record();
            }
            else if (recordButton.action.WasCompletedThisFrame() == true)
            {
                EndRecord();
            }
            else if (playButton.action.WasPressedThisFrame() == true)
            {
                PlaySound();
            }
        }
    }

    public void Record()
    {
        clip = Microphone.Start(null, false, 3599, AudioSettings.outputSampleRate);
    }

    public void EndRecord()
    {
        Microphone.End(null);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        /*if (collision.gameObject.CompareTag("Hand"))
        {
            
        }*/
        Record();
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
