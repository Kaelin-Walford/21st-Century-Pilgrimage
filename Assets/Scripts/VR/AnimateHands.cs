using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    public InputActionProperty triggerValue;
    public InputActionProperty gripValue;
    public InputActionProperty aValue;
    public InputActionProperty bValue;

    public Animator handAnimator;

    public static bool Gcord = false;
    public static bool Ccord = false;
    void Update()
    {
        //Animates the player hands
        float trigger = triggerValue.action.ReadValue<float>();
        float grip = gripValue.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", trigger);
        handAnimator.SetFloat("Grip", grip);

        if (transform.tag == "Right Hand")
        {
            if (aValue.action.WasPressedThisFrame() == true)
            {
                handAnimator.SetFloat("G", 100);
                Gcord = true;
            }
            else if (aValue.action.WasCompletedThisFrame() == true)
            {
                handAnimator.SetFloat("G", 0);
                Gcord = false;
            }

            if (bValue.action.WasPressedThisFrame() == true)
            {
                handAnimator.SetFloat("C", 100);
                Ccord = true;
            }
            else if (bValue.action.WasCompletedThisFrame() == true)
            {
                handAnimator.SetFloat("C", 0);
                Ccord = false;
            }
        }
    }
}
