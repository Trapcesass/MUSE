using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KunstSelector : MonoBehaviour
{
    private bool debounce = false;
    private Sprite[] sprites;
    private int pointer = 0;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new Sprite[] {
            Resources.Load<Sprite>("Art/kunstwerkAI"),
            Resources.Load<Sprite>("Art/kunstwerkSN"),
            Resources.Load<Sprite>("Art/Eclecticism"),
        };

        GameObject painting = GameObject.Find("kunstwerkAI");
        if (painting == null)
        {
            Debug.LogError("Couldnt find painting");
            return;
        }

        SpriteRenderer renderer = painting.GetComponent<SpriteRenderer>();
        if (renderer == null)
        {
            Debug.LogError("Couldnt find sprite renderer");
            return;
        }

        renderer.sprite = sprites[0];
        spriteRenderer = renderer;
    }

    // Update is called once per frame
    async void Update()
    {
        if (!debounce && SerialReader.instruction != null)
        {
            debounce = true;

            switch (SerialReader.instruction)
            {
                case SerialReader.Instruction.MOVE_LEFT:
                    pointer = pointer == 0 ? sprites.Length - 1 : pointer - 1;
                    break;
                case SerialReader.Instruction.MOVE_RIGHT:
                    pointer = pointer == sprites.Length - 1 ? 0 : pointer + 1;
                    break;
                case SerialReader.Instruction.MOVE_UP:
                    SceneManager.LoadScene("STARTSCENE");
                    break;
            }

            spriteRenderer.sprite = sprites[pointer];

            await Task.Delay(200);

            debounce = false;
        }
    }
}