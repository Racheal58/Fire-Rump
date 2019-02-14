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
        //Sets the score to zero with the application is opened
        score = 0;
    }
    private void Start() {
        //Set the highscore in the title page to the current highscore
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        //Displays get ready text at the beginning of the game
        scoreText.text = "Get Ready";
    }
    private void Update() {
        //checks if the rocks have started to spawn and then begins the score count
        if (spawn.started) {
            //The score consist of the time since the scene loaded, pick up points 
            score = ((int)Time.timeSinceLevelLoad + player.points) - spawn.startTime;
            scoreText.text = score.ToString();
        } else {
            //if it hasn't started, score doesnt count.
            score = 0;
        }
        //checks if current score is greater than the highscore and sets it as the new highscore
        if (score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "Highscore: " + score.ToString();
        }
    }

    public void Reset() {
        //Helpful function for reseting the highscore, you'll have to attach it to a button for it to work. Only for developers 
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "High Score: 0";
    }

}