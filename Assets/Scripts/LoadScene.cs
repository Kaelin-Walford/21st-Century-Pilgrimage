using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    public void loadscene()
    {
        //loads a scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
