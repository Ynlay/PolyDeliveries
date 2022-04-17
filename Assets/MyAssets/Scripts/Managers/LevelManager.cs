using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenu; 
    private bool menuActive = false;
    
    [Header("Game Over Panel")]
    public GameObject gameOver;
    public TextMeshProUGUI completed;
    public TextMeshProUGUI failed;
    public TextMeshProUGUI score;
    public TextMeshProUGUI reason;

    [Header("Help Panel")]
    public GameObject helpPanel;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.CompleteOrders = 0;
        PlayerStats.FailedOrders = 0;
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menuActive) {
                ContinueGame();
            } else {
                PauseGame();
            }
        }

        if (Input.GetKey(KeyCode.Q)) {
            helpPanel.SetActive(true);
        } else {
            helpPanel.SetActive(false);
        }
    }
    
    
    public void RestartScene() {
        menuActive = false;
        Time.timeScale = 1;
        print("Loading: " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueGame() {
        menuActive = false;
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void PauseGame() {
        menuActive = true;
        mainMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitGame() {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void GameOver(int _completed, int _failed, int _score, string _reason) {
        completed.text = "Orders Complete: " + _completed;
        failed.text = "Orders Failed: " + _failed;
        score.text = "Score Reached: " + _score;
        reason.text = "Reason: " + _reason;
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
