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
    private int expireTime = 5;
    private void Start() {
        InvokeRepeating("Spawn", startTime, spawnInterval);
        InvokeRepeating("SpawnFireExt", 10f, pickUpSpawnInterval);
    }

    private void Update() {
        if (player.playerDead) {
            CancelInvoke();
        }
    }

    private void Spawn() {
        int cur = Random.Range(0, spawnPoints.Length);
        GameObject ball = Instantiate(fallingRock, spawnPoints[cur].position, Quaternion.identity) as GameObject;
        started = true;
        if (Time.timeSinceLevelLoad > 30) {
            ball.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        if (Time.timeSinceLevelLoad > 60) {
            ball.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        if (Time.timeSinceLevelLoad > 100) {
            ball.GetComponent<Rigidbody2D>().gravityScale = 4;
            ball.GetComponent<Rigidbody2D>().mass = 4;
        }
    }

    private void SpawnFireExt() {
        if (started) {
            int num = Random.Range(0, fireExtingisherSpawnPoints.Length);
            fireExt = Instantiate(fireExtingisher, fireExtingisherSpawnPoints[num].position, Quaternion.identity);
            GetComponent<AudioSource>().Play();

            Destroy(fireExt, expireTime);
        }
    }
}
