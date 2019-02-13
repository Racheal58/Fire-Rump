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
        float h = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(h * speed, 0f);
    }
    private void Update() {
        playerAnim.SetFloat("DirX", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") > 0.01f) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Rock")) {
            playerDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PickUp")) {
            points = 10;
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.1f);
        }
    }
}
