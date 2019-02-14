using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
    public Animator camAnim;
    private void OnCollisionEnter2D(Collision2D other) {
        //Checks if the rock hits the floor in order to destroy the rock gameobject after a specified time.
        if (other.gameObject.CompareTag("Rock")) {
            //sets the trigger for the camera to shake animation
            camAnim.SetTrigger("Shake");
            //Plays the explosion sound associated with the rock
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.1f);
        }
    }
}
