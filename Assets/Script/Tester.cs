using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public string LoadScene;
    

    // Update is called once per frame
    public void OnButtonClick()
    {
        
        LoadingSceneController.LoadScene(LoadScene);
        
    }
}
