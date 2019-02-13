using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIControl : MonoBehaviour {
    public Text scoreText;
    public Text highScore;
    public SpawnControl spawn;
    public PlayerControl player;
    private int score;
    private void Awake() {
        score = 0;
    }
    private void Start() {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        scoreText.text = "Get Ready";
    }
    private void Update() {
        if (spawn.started) {
            score = ((int)Time.timeSinceLevelLoad + player.points) - spawn.startTime;
            scoreText.text = score.ToString();
        } else {
            score = 0;
        }
        if (score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "Highscore: " + score.ToString();
        }
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "High Score: 0";
    }

}