using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonPressed : MonoBehaviour
{
    private LevelShowUI LevelIndicator;
    private StartButtonBehaviour StartButton;
    [SerializeField] int thisLevel;
    // Start is called before the first frame update
    void Start()
    {
        LevelIndicator = GameObject.Find("LevelIndicator").GetComponent<LevelShowUI>();
        StartButton = GameObject.Find("StartButton").GetComponent<StartButtonBehaviour>();

    }

    // Update is called once per frame

    public void ChangeState()
    {
        print("pressed");
        LevelIndicator.levelSelected = true;
        StartButton.levelSelected = true;
        StartButton.sceneID = thisLevel;
    }
}
