using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public bool isGameOver;

    void Start() {
        isGameOver = false;
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameOver = false;
    }
}
