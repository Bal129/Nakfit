using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    [Header("Health system")]
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;
    [SerializeField] private Transform[] _healthPoints;

    [Header("Developer options")]
    [SerializeField] private Slider _jumpSlider;
    [SerializeField] private float _jumpForceMultiplier = 1.5f;
    [SerializeField] private float _jumpForceMaximum = 8.0f;
    [SerializeField] private float _jumpForceMinimum = 2.0f;
    private float _jumpForce;
    [SerializeField] private bool _isAlive = true;
    [SerializeField] private bool _inImmortalMode = false;

    [Header("Scoring System")]
    [SerializeField] private GameManager _gameManager;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private bool jumpingAction;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _isAlive = true;
        _jumpSlider.minValue = 0;
        _jumpSlider.maxValue = _jumpForceMaximum;
        _currentHealth = _maxHealth;
        gameObject.transform.parent = null;
        Debug.Log("Current health: " + _currentHealth);
        jumpingAction = false;

        UpdateHealth(_currentHealth);

        // Animation defaults
        SetAnimation(true, false, false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && gameObject.transform.parent != null)
        {
            jumpingAction = true;
            
            if (_jumpForce > _jumpForceMaximum)
            {
                _jumpForce = 0;
                // UpdateSlider();
            }

            if (_jumpForce <= _jumpForceMaximum)
            {
                SetAnimation(false, true, false);
                _jumpForce += _jumpForceMultiplier * Time.deltaTime;
                // UpdateSlider();
            }

            UpdateSlider();
            // Debug.Log("[Holding down Space Key] Jump force: " + _jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && gameObject.transform.parent != null)
        {
            if (_jumpForce > _jumpForceMinimum)
            {
                jumpingAction = false;
                SetAnimation(false, false, true);
                _rb2d.AddForce(Vector2.right + (Vector2.up * _jumpForce), ForceMode2D.Impulse);
                // Debug.Log("[Release Space Key] Jumped with force: " + _jumpForce);
            }
            _jumpForce = 0;
            UpdateSlider();
        }

        if (!jumpingAction)
        {
            animator.SetFloat("Freefall", _rb2d.velocity.y);
        }

        if (!jumpingAction && _rb2d.velocity == Vector2.zero && gameObject.transform.parent != null)
        {
            SetAnimation(true, false, false);
        }
    }

    public void SetIsAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }

    public bool GetIsAlive()
    {
        return _isAlive;
    }

    void UpdateSlider() 
    {
        _jumpSlider.value = _jumpForce;
    }

    void UpdateHealth(int currentHealthPoint)
    {
        foreach (var healthPoint in _healthPoints)
        {
            healthPoint.gameObject.SetActive(false);
        }

        for (int i = 0; i < currentHealthPoint; i++)
        {
            _healthPoints[i].gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Border")
        {
            SetIsAlive(false);
            gameObject.transform.parent = null;
        }

        if (collision2D.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = collision2D.gameObject.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Obstacle" && !_inImmortalMode)
        {
            Destroy(collider2D.gameObject);
            _currentHealth--;
            Debug.Log("Current health: " + _currentHealth);
            UpdateHealth(_currentHealth);
            if (_currentHealth <= 0)
            {
                SetIsAlive(false);
                gameObject.transform.parent = null;
            }
        }

        if (collider2D.gameObject.tag == "Score")
        {
            ScoreBehavior scoreBehavior = collider2D.gameObject.GetComponent<ScoreBehavior>();
            _gameManager.SetScore(_gameManager.GetScore() + scoreBehavior.GetScoreValue());
            Destroy(collider2D.gameObject);
        }
    }

    private void SetAnimation(bool isIdling, bool isCrouching, bool isJumping)
    {
        animator.SetBool("IsIdling", isIdling);
        animator.SetBool("IsCrouching", isCrouching);
        animator.SetBool("IsJumping", isJumping);
    }
}
