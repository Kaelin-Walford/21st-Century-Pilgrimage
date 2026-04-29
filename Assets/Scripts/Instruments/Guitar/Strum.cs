using UnityEngine;

public class Strum : MonoBehaviour
{
    [SerializeField] Animator animator;
    public AudioSource regular;
    public AudioSource G;
    public AudioSource C;
    public string stringName = "";

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Hand")
        {
            animator.SetTrigger(stringName);
            if (AnimateHands.Ccord && AnimateHands.Gcord)
            {
                G.Play();
            }
            else if (AnimateHands.Gcord)
            {
                G.Play();
            }
            else if (AnimateHands.Ccord)
            {
                C.Play();
            }
            else
            {
                regular.Play();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Hand")
        {
            animator.SetTrigger("E");
        }
    }
}
