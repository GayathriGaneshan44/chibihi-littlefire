using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    

    [Header("MAIN MENU")]
    [SerializeField] private GameObject mainmenuscreen;

    private void Awake()
    {
        
        mainmenuscreen.SetActive(true);
    }
    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
        public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}