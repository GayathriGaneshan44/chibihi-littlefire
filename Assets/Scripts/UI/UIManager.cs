using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("End")]
    [SerializeField] private GameObject lcScreen;
    [SerializeField] private GameObject endingScene;
    [SerializeField] private AudioClip lcSound;



    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        lcScreen.SetActive(false);
        endingScene.SetActive(false);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause screen already active unpause and viceversa
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    #region Game Over
    //Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
       
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void LevelComplete()
    {
        lcScreen.SetActive(true);
        
        SoundManager.instance.PlaySound(lcSound);
    }

    public void GameEnded()
    {
        endingScene.SetActive(true);
        
        SoundManager.instance.PlaySound(lcSound);
    }

    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion

    public void LoadNextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}