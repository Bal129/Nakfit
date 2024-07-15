using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("For Menu Manager")]

    [SerializeField] private RectTransform _pauseMenu;
    [SerializeField] private RectTransform _endMenu;

    [Header("For End Menu")]

    [SerializeField] private Player _player;

    void Start()
    {
        Time.timeScale = 1;
        _pauseMenu.gameObject.SetActive(false);
        _endMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToPause();
        }

        if (!_player.GetIsAlive())
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        _endMenu.gameObject.SetActive(true);
    }

    public void ToPause()
    {
        Time.timeScale = 0;
        _pauseMenu.gameObject.SetActive(true);
    }
    
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _pauseMenu.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
