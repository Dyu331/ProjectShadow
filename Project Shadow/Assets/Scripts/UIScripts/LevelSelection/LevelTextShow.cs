using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTextShow : MonoBehaviour
{
    private StartButtonBehaviour StartButton;
    private TMP_Text levelNum;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        levelNum = GetComponent<TMP_Text>();
        StartButton = GameObject.Find("StartButton").GetComponent<StartButtonBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        num = StartButton.sceneID - 2;
        levelNum.text = "Level: " + num.ToString();
    }
}
