using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public AudioSource pauseSound;

    [SerializeField]
    public AudioSource bgMusic;

    [SerializeField]
    bool isPaused = false;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic.Play();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        bgMusic.Play();
        //PlayerMovement.velocity = Vector3.zero;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        pauseSound.Play();
        bgMusic.Pause();
        //CharacterController.velocity = Vector3.zero;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        bgMusic.Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        deathScreen.SetActive(false);
        bgMusic.Play();
    }
}
