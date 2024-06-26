using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabUIBehaviour : MonoBehaviour
{
    private MotionDetection MotionDetection;
    [SerializeField] Vector3 InSidePosition;
    [SerializeField] Vector3 OutSidePosition;

    public GameObject stabButton;

    // Start is called before the first frame update
    void Start()
    {
        MotionDetection = GameObject.Find("UICanvas").GetComponent<MotionDetection>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MotionDetection.shadowMode==false)
        {
            //GetComponent<Button>().interactable = false;
            //transform.position = OutSidePosition;

            stabButton.SetActive(false);
        }
        else if(MotionDetection.shadowMode == true)
        {
            //GetComponent<Button>().interactable = true;
            //transform.position = InSidePosition;

            Debug.Log("button");
            stabButton.SetActive(true);
        }
    }
}
