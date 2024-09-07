using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) ToGame();
        if (Input.GetKeyDown(KeyCode.Z)) ToTutorial();
        if (Input.GetKeyDown(KeyCode.Q)) ToQuit();
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ToQuit()
    {
        Application.Quit();
    }
}
