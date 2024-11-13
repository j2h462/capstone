using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1to2 : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("SecondScene");
    }

    
}
