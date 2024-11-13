using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2to1 : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("FirstScene");
    }

    
}
