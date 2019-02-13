using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
    public Animator camAnim;
    public bool hitFloor;

    private void Start() {

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Rock")) {
            camAnim.SetTrigger("Shake");
            hitFloor = true;
            other.gameObject.GetComponent<Animator>().SetBool("hitFloor", hitFloor);
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.1f);
        }
    }
}
