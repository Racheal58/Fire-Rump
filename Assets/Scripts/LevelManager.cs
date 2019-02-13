using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour {
    [SerializeField]
    private GameObject losePanel;

    private PlayerControl player;

    private void Awake() {
        losePanel = GameObject.Find("Lose Panel");
        losePanel.SetActive(false);
    }
    void Start() {
        player = FindObjectOfType<PlayerControl>();
        Time.timeScale = 1;
    }

    private void Update() {
        if (player.playerDead) {
            Lose();
        }
    }
    public void Lose() {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
    public void Quit() {
        Application.Quit();
        Debug.Log("Fake Quitting");
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
