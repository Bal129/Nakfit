using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ObstacleDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.tag == "Platform") 
        {
            Destroy(collision2D.gameObject);
        }
    }
}
