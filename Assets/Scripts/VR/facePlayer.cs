using UnityEngine;

public class facePlayer : MonoBehaviour
{
    public Vector3 defaultRotation;
    public RectTransform objTransform;
    public Transform playerTransform;

    void Start()
    {
        defaultRotation = objTransform.rotation.eulerAngles;
    }

    void Update()
    {
        objTransform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y + (playerTransform.rotation.y - 180), defaultRotation.z);
    }
}
