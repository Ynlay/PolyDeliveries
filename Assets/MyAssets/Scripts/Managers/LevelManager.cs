using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject mainMenu; 
    private bool menuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
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
    }
    
    
    public void RestartScene() {
        Time.timeScale = 1;
        print("Loading: " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueGame() {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void PauseGame() {
        mainMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitGame() {
        Time.timeScale = 1;
        Application.Quit();
    }
}
