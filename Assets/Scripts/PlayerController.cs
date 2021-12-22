using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Just as a note, setting the Rigidbody to Kinematic helped with the ball slowing down
    private Rigidbody2D rb;
    GameManager gameManager;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, 0.0f);

        // Clamps the player so they can't go off the edge of the screen
        if (transform.position.x <= -7)
            transform.position = new Vector2(-7, -4);
        else if (transform.position.x >= 7)
            transform.position = new Vector2(7, -4);

        // Prevents the player from moving when the game is over
        if (gameManager.isGameActive)
            rb.velocity = movement;
        else
            rb.velocity = Vector2.zero;
    }
}
