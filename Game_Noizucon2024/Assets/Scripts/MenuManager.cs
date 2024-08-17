using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) ToGame();
        if (Input.GetKeyDown(KeyCode.Q)) ToQuit();
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToQuit()
    {
        Application.Quit();
    }
}
