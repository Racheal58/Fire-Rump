using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed;
    public bool playerDead;
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private LevelManager levelManager;
    private float timeElapsed;
    public int points;
    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
        playerAnim = GetComponent<Animator>();
        points = 0;
    }
    private void FixedUpdate() {
        //Stores the input from the horizontal keys in h and then changes the player velocity based on the value of h and a speed multiplier
        float h = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(h * speed, 0f);
    }
    private void Update() {
        //Uses this to determine when the player animation for walk is activated
        playerAnim.SetFloat("DirX", Mathf.Abs(Input.GetAxis("Horizontal")));

        //Checks if the player is moving right and flips the player
        if (Input.GetAxis("Horizontal") > 0.01f) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Checks if the player is moving left and flips the player
        if (Input.GetAxis("Horizontal") < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        //Checks if the player colides with the falling rocks
        if (other.gameObject.CompareTag("Rock")) {
            playerDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Checks if the player enters into the pick up, then adds a point and destories the pick up.
        if (other.gameObject.CompareTag("PickUp")) {
            points = 10;
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.1f);
        }
    }
}
