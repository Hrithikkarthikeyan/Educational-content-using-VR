
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshPro textGameOver;
    void Start()
    {
       int score = PlayerPrefs.GetInt("Score", 0);
        textGameOver.text = "உங்கள் மதிப்ெபண்:" + score  ;

    }
      
    public void PlayAgain()
    {

        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
   


}
