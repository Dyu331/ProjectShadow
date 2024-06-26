using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelShowUI : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] Vector3 posInside;
    [SerializeField] Vector3 posOutside;
    public bool levelSelected = false;
    //private StartButtonBehaviour StartButton;
    //private TMP_Text levelNum;
    private void Start()
    {
        //levelNum = GetComponent<TMP_Text>();
        //StartButton = GameObject.Find("StartButton").GetComponent<StartButtonBehaviour>();
    }
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
}
