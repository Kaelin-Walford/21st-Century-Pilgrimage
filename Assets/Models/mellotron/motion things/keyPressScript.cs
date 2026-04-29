using UnityEngine;

public class keyPressScript : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Hand"))
        {
            audioSource.Play();
            anim.SetBool("OnTrigEnter", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("OnTrigEnter", false);
    }
}
