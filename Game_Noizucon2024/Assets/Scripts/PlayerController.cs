using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField] private Slider jumpSlider;
    [SerializeField] private float jumpForceMultiplier = 1.5f;
    [SerializeField] private float jumpForceMaximum = 8.0f;
    private float jumpForce;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpSlider.minValue = 0;
        jumpSlider.maxValue = jumpForceMaximum;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            if (jumpForce <= jumpForceMaximum) {
                jumpForce += jumpForceMultiplier * Time.deltaTime;
                UpdateSlider();
            }
            Debug.Log("[Holding down Up Key] Jump force: " + jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("[Release Up Key] Jumped with force: " + jumpForce);
            jumpForce = 0;
            UpdateSlider();
        }

    }

    // Call by slider in OnChangeValue()
    void UpdateSlider() {
        jumpSlider.value = jumpForce;
    }
}
