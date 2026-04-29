using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.OpenXR.NativeTypes;

public class GrabHandPose : MonoBehaviour
{
    public HandData rightHand;
    public HandData leftHand;
    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Vector3 guitarPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(SetupPose);
        grabInteractable.selectExited.AddListener(endGrip);
        rightHand.gameObject.SetActive(false);
        leftHand.gameObject.SetActive(false);
    }

    //repositions the hand when grabing the guitar so it places it at the top
    public void SetupPose(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            HandData handData = args.interactorObject.transform.parent.GetComponentInChildren<HandData>();

            if(handData.handType == HandData.HandModelType.Right)
            {
                SetHandDataValues(handData, rightHand);
                handData.animator.SetTrigger("Hold Guitar Trigger");
            }
            else
            {
                SetHandDataValues(handData, leftHand);
            }
            
            SetHandData(handData, rightHand.transform.parent.gameObject, finalHandPosition, finalHandRotation);
        }
    }
    public void SetHandDataValues(HandData hand1, HandData hand2)
    {
        startingHandPosition = hand1.root.localPosition;
        finalHandPosition = hand2.root.localPosition;
        startingHandRotation = hand1.root.localRotation;
        finalHandRotation = hand2.root.localRotation;
    }

    public void SetHandData(HandData hand, GameObject guitar, Vector3 newPosition, Quaternion newRotation)
    {
        hand.root.localPosition = newPosition;
        hand.root.localRotation = newRotation;
    }

    public void endGrip(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            HandData handData = args.interactorObject.transform.parent.GetComponentInChildren<HandData>();

            if (handData.handType == HandData.HandModelType.Right)
            {
                SetHandData(handData, rightHand.transform.parent.gameObject, startingHandPosition, startingHandRotation);
                handData.animator.SetTrigger("Let Go of Guitar Trigger");
            }
        }
    }
}
