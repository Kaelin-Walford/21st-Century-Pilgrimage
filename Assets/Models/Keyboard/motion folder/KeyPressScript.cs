using UnityEngine;

public class KeyPressScript : MonoBehaviour
{
    public Animator anim;
    public AudioSource audiosource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Hand"))
        {
            audiosource.Play();
            anim.SetBool("OnTrigEnter", true);
            print("test");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("OnTrigEnter", false);
    }
}
