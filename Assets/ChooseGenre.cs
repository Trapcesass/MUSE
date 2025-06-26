using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGenre : MonoBehaviour
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
            switch (SerialReader.instruction)
            {
                case SerialReader.Instruction.MOVE_LEFT:
                    SceneManager.LoadScene("MUSICSCENEMOCKUP");
                    break;
                case SerialReader.Instruction.MOVE_RIGHT:
                    SceneManager.LoadScene("ARTSCENEMOCKUP");
                    break;
                case SerialReader.Instruction.MOVE_UP:
                    SceneManager.LoadScene("STARTSCENE");
                    break;
            }
            loadingScene = false;
        }
    }
}