using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToGame();
        }
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
