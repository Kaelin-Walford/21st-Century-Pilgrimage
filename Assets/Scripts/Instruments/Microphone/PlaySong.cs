using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.InputSystem;

public class PlaySong : MonoBehaviour
{
    public AudioSource sound;
    public InputActionProperty playButton;

    public static int grabbed = 0;

    void Update()
    {
        //plays the song while button pressed
        if (grabbed > 0)
        {
            if (playButton.action.WasPressedThisFrame() == true)
            {
                sound.Play();
            }
            else if (playButton.action.WasCompletedThisFrame() == true)
            {
                sound.Stop();
            }
        }
    }
}
