using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButtonBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] Vector3 posInside;
    [SerializeField] Vector3 posOutside;
    public bool levelSelected = false;
    public int sceneID = 0;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Debug.Log(levelSelected);
        if (levelSelected == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, posOutside, speed);
        }else if (levelSelected == false)
        {
            transform.position = Vector3.MoveTowards(transform.position,posInside, speed);
        }

    }
    public void MoveToScene()
    {
        print("Pressed");
        SceneManager.LoadScene(sceneID);
    }
}
