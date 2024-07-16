using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PlatformBehavior : MonoBehaviour
{
    private BoxCollider2D _bc2d;

    [SerializeField] private float _platformSpeed;
    
    void Update()
    {
        transform.Translate(Vector2.left * _platformSpeed * Time.deltaTime);
    }
}
