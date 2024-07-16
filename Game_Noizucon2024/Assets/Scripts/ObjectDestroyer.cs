using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ObjectDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.tag == "Platform" || 
            collision2D.gameObject.tag == "Obstacle" ||
            collision2D.gameObject.tag == "Player")
        {
            Destroy(collision2D.gameObject);
        }
    }
}
