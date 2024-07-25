using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] private float _obstacleSpeed;

    void Update()
    {
        transform.Translate(Vector2.left * _obstacleSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.tag == "Player" || 
            collision2D.gameObject.tag == "Platform" ||
            collision2D.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
