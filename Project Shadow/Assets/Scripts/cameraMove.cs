using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    

    public Vector3 offset;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.FindWithTag("Player").transform.position + offset;
    }
}
