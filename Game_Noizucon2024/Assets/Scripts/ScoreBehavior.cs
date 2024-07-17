using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoreBehavior : MonoBehaviour
{
    [Header("To reference the game manager")]
    [SerializeField] private GameManager gameManager;

    [Header("Value of the score")]
    [SerializeField] private int _scoreValue;

    public int GetScoreValue()
    {
        return _scoreValue;
    }
}
