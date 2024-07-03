using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.gameObject.tag == "Obstacle") {
            Debug.Log("Collided");
        }
    }
}
