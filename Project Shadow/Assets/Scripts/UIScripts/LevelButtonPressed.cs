using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonPressed : MonoBehaviour
{
    public bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(isPressed);
    }
    public void ChangeState()
    {
        isPressed = true;
    }
}
