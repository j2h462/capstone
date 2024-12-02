using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_menu : MonoBehaviour
{
    public GameObject option_menu;
    public GameObject exit_menu;

        public void Option_btn_clicked()
    {
       option_menu.SetActive(true);
        
    }

     public void Exit_btn_clicked()
    {
       exit_menu.SetActive(true);
        
    }

    public void option_back_btn_clicked()
    {
        option_menu.SetActive(false);
       
    }

     public void no_btn_clicked()
    {
       exit_menu.SetActive(false);
      
    }
}
