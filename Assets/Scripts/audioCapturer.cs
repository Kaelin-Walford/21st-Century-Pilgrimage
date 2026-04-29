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

    public static bool grabbed = false;

    void Update()
    {
        if (grabbed)
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
        print("1");
    }

    public void EndRecord()
    {
        Microphone.End(null);
        print("2");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        /*if (collision.gameObject.CompareTag("Hand"))
        {
            
        }*/
        Record();
        print("1");
    }

    private void OnCollisionExit(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Hand"))
        { 
            Microphone.End(null);
            print("2");
        }

        PlaySound();
        print("3");
    }


    public void PlaySound()
    {
        Source.clip = clip;
        Source.Play();
        print("3");
    }
}
