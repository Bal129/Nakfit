using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ObstacleBehavior : MonoBehaviour
{
    private BoxCollider2D bc2d;

    [SerializeField] private float obstacleSpeed;
    
    void Update()
    {
        transform.Translate(Vector2.left * obstacleSpeed * Time.deltaTime);
    }
}
