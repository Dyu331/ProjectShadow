using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScript : MonoBehaviour
{
    [SerializeField] Vector3 posInside;
    [SerializeField] Vector3 posOutside;
    private MotionDetection MotionDetect;
    // Start is called before the first frame update
    void Start()
    {
        MotionDetect = GameObject.Find("UICanvas").GetComponent<MotionDetection>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MotionDetect.isSkiping == true)
        {
            transform.position = posOutside;
            GetComponent<Animator>().SetBool("isPressed", true);

        }
        else if (MotionDetect.isSkiping == false)
        {
            transform.position = posInside;
            GetComponent<Animator>().SetBool("isPressed", false);
        }
    }
}
