using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    GameManager gameManager;

    [SerializeField] private float force;
    [SerializeField] private float initialSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.up * force);
        rb.velocity = Vector2.up * initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Mainly used for when the level is finished to prevent the Game Over Screen from appearing
        if (!gameManager.isGameActive)
            rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        //EnsureVelocity();
    }

    private void EnsureVelocity()
    {
        var currentSpeed = rb.velocity.magnitude;
        if (Mathf.Abs(currentSpeed - initialSpeed) > 0.1f)
            rb.velocity = rb.velocity / currentSpeed * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            gameManager.BrickBroken();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bounds"))
        {
            gameManager.GameOver();
            gameObject.SetActive(false);
        }
    }
}
