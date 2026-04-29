using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class vrControl : MonoBehaviour
{
    //for detecting when object is grabbed
    public XRGrabInteractable grabInteractable;
    void Start()
    {
        grabInteractable.selectEntered.AddListener(Grab);
        grabInteractable.selectExited.AddListener(EndGrab);
    }
    public void Grab(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            PlaySong.grabbed++;
        }
    }
    
    public void EndGrab(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            PlaySong.grabbed--; 
        }
    }

}
