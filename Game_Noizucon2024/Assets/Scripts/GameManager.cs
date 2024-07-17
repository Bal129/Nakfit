using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("For Menu Manager")]

    [SerializeField] private RectTransform _pauseMenu;
    [SerializeField] private RectTransform _endMenu;

    [Header("For End Menu")]

    [SerializeField] private Player _player;

    [Header("Scoring System")]
    [SerializeField] private int _score;
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private TextMeshProUGUI _textFinalScore;

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

        _textScore.text = "Score: " + _score;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        _textFinalScore.text = "Final Score: " + _score;
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

    public void SetScore(int score)
    {
        _score = score;
    }

    public int GetScore()
    {
        return _score;
    }
}
