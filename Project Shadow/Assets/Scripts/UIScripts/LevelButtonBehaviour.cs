using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelButtonBehaviour : MonoBehaviour
{
    private TMP_Text LevelText;
    public int LevelNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        LevelText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelText.text = "Level " + LevelNumber;
    }
}
