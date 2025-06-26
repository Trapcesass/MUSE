using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private bool loadingScene = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!loadingScene && SerialReader.instruction != null)
        {
            loadingScene = true;
            SceneManager.LoadScene("CHOOSINGSCENE");
            loadingScene = false;
        }
    }
}