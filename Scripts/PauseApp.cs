using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseApp : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject pausePos;
    public float speed = 1;

    bool flag = false;
    Vector3 currentPos;
 
    
    
    void Update()
    {
        //if(completeLevelUI.active == true){
        if(!flag){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
        	//if(gamePaused == false){
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                currentPos = player.transform.localPosition;
                player.transform.localPosition = pausePos.transform.localPosition;
                Debug.Log("Updatein");
                flag = true;
            //}
        }
    }
    }

    public void UnpauseGame(){
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = speed;
        player.transform.localPosition = currentPos;
        Invoke("setFlag",1);
    }

    public void SetSpeed1(){
    	Debug.Log("set1");
        speed = 1;
        UnpauseGame();
    }
    public void SetSpeed2(){
    	Debug.Log("set2");
        speed = 1.5f;
        UnpauseGame();
    }
    public void SetSpeed3(){
    	Debug.Log("set3");
        speed = 2;
        UnpauseGame();
    }

    public void Restart(){
    	SceneManager.LoadScene("01");
    	UnpauseGame();
    }
    public void Quit(){
    	 //Application.Quit();
    	 Debug.Log("quit");
    	#if UNITY_EDITOR
         	UnityEditor.EditorApplication.isPlaying = false;
     	#else
         	Application.Quit();
     	#endif
    }

    void setFlag(){
        flag = false;
    }
}
