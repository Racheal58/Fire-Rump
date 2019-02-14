using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour {
    //A lose panel is used instead of a lose scene to keep the game light weight
    [SerializeField]
    private GameObject losePanel;
    private PlayerControl player;
    public AudioSource sound;
    private void Awake() {
        //Find the loose panel automatically and turn it off at start of game
        losePanel = GameObject.Find("Lose Panel");
        losePanel.SetActive(false);
        //Search game object for the sound
        sound = GetComponent<AudioSource>();
    }
    void Start() {
        player = FindObjectOfType<PlayerControl>(); //Find player in the scene
        sound.Play();
        Time.timeScale = 1; //Set the time to normal time 
    }

    private void Update() {
        //checks every frame if the player is dead and calls the lose function
        if (player.playerDead) {
            Lose();
        }
    }
    public void Lose() {
        //set turns the lose panel on and pause time progressionw
        losePanel.SetActive(true);
        Time.timeScale = 0;
        sound.Stop();
    }
    public void LoadScene(string name) {
        //Load the scene with inputed name
        SceneManager.LoadScene(name);
    }
    public void Quit() {
        //closes the application
        Application.Quit();
        Debug.Log("Fake Quitting");
    }
    public void Restart() {
        //Load the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
