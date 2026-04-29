using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRDirectInteractorPositionSnap : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;
    //allows for different positions depending on what hand grabs the object
    public override Transform GetAttachTransform(IXRInteractor interactor)
    {
        if (interactor.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftAttachTransform;
        }
        else if (interactor.transform.CompareTag("Right Hand"))
        {
            attachTransform = rightAttachTransform;
        }
        
        return base.GetAttachTransform(interactor);
    }
}
