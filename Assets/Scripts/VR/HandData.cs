using UnityEngine;

public class HandData : MonoBehaviour
{
    //stores data for use in moving the hand
    public enum HandModelType { Left, Right }

    public HandModelType handType;
    public Transform root;
    public Animator animator;
    public Transform[] fingers;
}
