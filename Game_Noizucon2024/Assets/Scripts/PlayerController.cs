using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    [SerializeField] private Slider _jumpSlider;
    [SerializeField] private float _jumpForceMultiplier = 1.5f;
    [SerializeField] private float _jumpForceMaximum = 8.0f;
    private float _jumpForce;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _jumpSlider.minValue = 0;
        _jumpSlider.maxValue = _jumpForceMaximum;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            if (_jumpForce <= _jumpForceMaximum) 
            {
                _jumpForce += _jumpForceMultiplier * Time.deltaTime;
                UpdateSlider();
            }
            Debug.Log("[Holding down Up Key] Jump force: " + _jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) 
        {
            _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("[Release Up Key] Jumped with force: " + _jumpForce);
            _jumpForce = 0;
            UpdateSlider();
        }

    }

    void UpdateSlider() {
        _jumpSlider.value = _jumpForce;
    }
}
