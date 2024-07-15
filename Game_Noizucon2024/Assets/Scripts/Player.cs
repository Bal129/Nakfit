using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    [Header("Developer options")]
    [SerializeField] private bool _isAlive = true;
    [SerializeField] private bool _inImmortalMode = false;

    public void SetIsAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }

    public bool GetIsAlive()
    {
        return _isAlive;
    }

    void Start()
    {
        _isAlive = true;
        this.gameObject.transform.parent = null;
    }

    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.tag == "Obstacle" && !_inImmortalMode)
        {
            Debug.Log("Dead");
            SetIsAlive(false);
        }

        if (collision2D.gameObject.tag == "Platform")
        {
            this.gameObject.transform.parent = collision2D.gameObject.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Platform")
        {
            this.gameObject.transform.parent = null;
        }
    }
}
