using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("For Menu Manager")]
    [SerializeField] private RectTransform _pauseMenu;
    [SerializeField] private RectTransform _endMenu;

    [Header("For End Menu")]
    [SerializeField] private PlayerController _player;

    [Header("Scoring System")]
    [SerializeField] private int _score;
    [SerializeField] private int _maxScore;
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
        if (Input.GetKeyDown(KeyCode.P) && _player.GetIsAlive())
        {
            ToPause();
        }

        if (_pauseMenu.gameObject.activeInHierarchy) {
            if (Input.GetKeyDown(KeyCode.U)) Resume();
            if (Input.GetKeyDown(KeyCode.I)) Restart();
            if (Input.GetKeyDown(KeyCode.O)) ToMenu();
        }

        if (_endMenu.gameObject.activeInHierarchy) {
            if (Input.GetKeyDown(KeyCode.K)) ToMenu();
        }

        if (!_player.GetIsAlive())
        {
            EndGame();
        }

        if (_score < _maxScore)
        {
            _textScore.text = "Score: " + _score;
        } 
        else if (_score == _maxScore)
        {
            _textScore.text = "Max Score Reached! (" + _score + "/" + _maxScore + ") ";
        }
        else if (_score > _maxScore)
        {
            _textScore.text = "Highest Score: " + _score;
        }
        
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
