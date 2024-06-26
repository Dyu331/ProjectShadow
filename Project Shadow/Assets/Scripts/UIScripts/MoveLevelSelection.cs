using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelSelection : MonoBehaviour
{
    Vector2 MoveLevelLocation;
    private bool tap, swipeLeft, swipeRight;
    private Vector2 startPos,endPos, swipeDelta;
    private void Update()
    {
        print(swipeDelta);
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                endPos = Input.touches[0].position;
                if (Input.touches.Length > 0)
                {
                    swipeDelta = endPos - startPos;

                }
                Reset();
                
            }
        }





    }
    private void Reset()
    {
        print("reset");
        startPos = endPos = swipeDelta = Vector2.zero;
        
    }
}
