using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class onClick_MainMenu : MonoBehaviour
{
    public GameObject option_menu;
    public GameObject mainmenu;
    public GameObject exit_menu;
    public static bool GameIsPaused = false;
     
     

    

     void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
            } else {
                Pause();
            }
        }
    }
    public void Resume_btn_clicked(){
        mainmenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        mainmenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void Option_btn_clicked()
    {
       mainmenu.SetActive(false);
       option_menu.SetActive(true);
        
    }

     public void Exit_btn_clicked()
    {
       mainmenu.SetActive(false);
       exit_menu.SetActive(true);
        
    }

    public void option_back_btn_clicked()
    {
        option_menu.SetActive(false);
        mainmenu.SetActive(true);
    }

     public void no_btn_clicked()
    {
       exit_menu.SetActive(false);
       mainmenu.SetActive(true);
    }
}
