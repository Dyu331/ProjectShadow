using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    // Start is called before the first frame update
    void Start()
    {
        tap = swipeLeft = swipeRight = false;
    }

    // Update is called once per frame
    private void Update()
    {
        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;

                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            /*else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }*/
        }

            float x = swipeDelta.x;
            if (x < 0)
            {
                swipeLeft = true;
            }
            else if (x > 0)
            {
                swipeRight = true;

            }
            Reset();
        
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
