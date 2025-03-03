using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChoice : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private bool play;
    [SerializeField] private bool option;
    [SerializeField] private bool quit;
    [SerializeField] private bool back;

    [Header("Reference")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private string sceneToLoad;

    public void OnClick()
    {
        if(play)
        {
            Play();
        }
        else if (option)
        {
            Option();
        }
        else if (back)
        {
            Back();
        }
        else if (quit)
        {
            Quit();

        }
    }

    void Play()
    {
        print("Play");
        SceneManager.LoadScene(sceneToLoad);
    }
    void Option()
    {
        print("Option");
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    void Back()
    {
        print("Back");
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    void Quit()
    {
        print("Quit");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
