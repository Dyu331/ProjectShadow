using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TipScript : MonoBehaviour
{
    private TMP_Text TipText;
    public int TipNum;
    [SerializeField] Vector3 posInside;
    [SerializeField] Vector3 posOutside;


    // Start is called before the first frame update
    void Start()
    {
        TipText = GameObject.Find("TipText").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (TipNum)
        {
            case 1:
                transform.position = posInside;
                TipText.text = "Swipe to move";
                break;
            case 2:
                transform.position = posInside;
                TipText.text = "Enemy is nearby, hide in the corner";
                break;
            case 3:
                transform.position = posInside;
                TipText.text = "Hold screen to skip your turn";
                break;
            case 4:
                transform.position = posInside;
                TipText.text = "Double tap to enter Shadow Mode, be aware that it costs Shadow Energy";
                break;
            case 5:
                transform.position = posInside;
                TipText.text = "Click the strike button to kill the enemy next to you";
                break;
            default:
                transform.position = posOutside;
                TipText.text = "";
                
                break;
        }
    }
}
