using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    // Start is called before the first frame update



    public void MoveToScene(int sceneID)
    {   
        print("Pressed");
        SceneManager.LoadScene(sceneID);
    }
}
