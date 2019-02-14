using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnControl : MonoBehaviour {
    public GameObject fallingRock;
    public GameObject fireExtingisher;
    GameObject fireExt;
    public PlayerControl player;
    public Transform[] spawnPoints;
    public Transform[] fireExtingisherSpawnPoints;
    public float spawnInterval;
    public float pickUpSpawnInterval = 50f;
    public int startTime = 2;
    public bool started;
    private int expireTime = 4;
    private void Start() {
        //Inoves the spawn and pickup function after a certain wait them and repeats it after a given internval, really helpful funtion for recursive task
        InvokeRepeating("Spawn", startTime, spawnInterval);
        InvokeRepeating("SpawnFireExt", 10f, pickUpSpawnInterval);
    }

    private void Update() {
        //Checks if the player is dead and cancels all inovokes
        if (player.playerDead) {
            CancelInvoke();
        }
    }

    private void Spawn() {
        //Uses a randomized int to determine the spawn position from an array of positions.
        int cur = Random.Range(0, spawnPoints.Length);
        GameObject ball = Instantiate(fallingRock, spawnPoints[cur].position, Quaternion.identity) as GameObject;
        //Send a message that spawning has started.
        started = true;

        //The simple progressive difficulty controller, changes the speed at which the balls decend
        if (Time.timeSinceLevelLoad > 30) {
            ball.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        if (Time.timeSinceLevelLoad > 60) {
            ball.GetComponent<Rigidbody2D>().gravityScale = 3;
            ball.GetComponent<Rigidbody2D>().mass = 3;
        }
        if (Time.timeSinceLevelLoad > 100) {
            ball.GetComponent<Rigidbody2D>().gravityScale = 4;
            ball.GetComponent<Rigidbody2D>().mass = 4;
        }
    }

    private void SpawnFireExt() {
        //Spawns the pick ups after the game has started and plays sound associated with it.
        if (started) {
            int num = Random.Range(0, fireExtingisherSpawnPoints.Length);
            fireExt = Instantiate(fireExtingisher, fireExtingisherSpawnPoints[num].position, Quaternion.identity);
            GetComponent<AudioSource>().Play();

            //Destory the pickup after a given time if the player doesn't pick it up.
            Destroy(fireExt, expireTime);
        }
    }
}
