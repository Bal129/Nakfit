using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField] private float jumpForce;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
