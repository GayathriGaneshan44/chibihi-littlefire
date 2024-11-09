using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private UIManager uim;

    public void Awake()
    {
        uim = FindObjectOfType<UIManager>();
    }

    public void OnTriggerEnter2D()
    {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (currentSceneIndex == lastSceneIndex)
        {
            uim.GameEnded();
        }
        uim.LevelComplete();
    }
    /*public GameObject levelCompleteUI; // Assign your level complete UI in the Inspector
    public GameObject endingUI; // Assign your ending UI in the Inspector

    public void OnLevelEndReached()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (currentSceneIndex == lastSceneIndex)
        {
            // Show the ending UI with credits for the last level
            endingUI.SetActive(true);
        }
        else
        {
            // Show the level complete UI for other levels
            levelCompleteUI.SetActive(true);
        }
    }*/
    
}
