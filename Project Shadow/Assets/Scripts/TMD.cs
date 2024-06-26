using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMD : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool firstTapEnd;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    [SerializeField] float doubletTapTime=0.2f;
    public bool shadowMode = false;
    float touchTime;
    private bool onHold = false;
    private bool held = false;

    float holdTime = 0f;
    private void Update()
    {
        Debug.Log(onHold);
        Debug.Log(holdTime);
        Debug.Log(held);
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
        #region StandALone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion
        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {

                onHold = true;
                if (firstTapEnd&&touchTime <= doubletTapTime )
                {
                    onHold = false;
                    isDraging = false;
                    print("doubleTap");
                    touchTime = 0;
                    shadowMode = !shadowMode;
                    print(shadowMode);
                }
                firstTapEnd = false;
                isDraging = true;
                startTouch = Input.touches[0].position;

            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                onHold = false;
                firstTapEnd = true;
                if (holdTime >= 1.3f)
                {
                    holdTime = 0f;
                    held = true;
                    firstTapEnd = false;
                }
                else
                {
                    holdTime = 0f;
                }
                Reset();
                
            }
        }
        #endregion
        swipeDelta = Vector2.zero;
        if (firstTapEnd && touchTime<= doubletTapTime)
        {
            touchTime += Time.deltaTime;
        }
        else{
            firstTapEnd = false;
            touchTime = 0;
            
        }
        if(onHold == true && holdTime<=1.5f)
        {
            holdTime += Time.deltaTime;
        }

        


        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            } else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        //when swipe magnitude > 85, read input and take action
        if (swipeDelta.magnitude > 85)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true;
                } else if (x > 0)
                {
                    swipeRight = true;

                }
            }
            else {
                if (y < 0)
                {
                    swipeDown = true;
                }
                else if (y > 0)
                {
                    swipeUp = true;

                }
            }
            Reset();
        }

    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
    public bool Tap { get{ return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }


}
