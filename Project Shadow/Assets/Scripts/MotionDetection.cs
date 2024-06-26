using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDetection : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    [SerializeField] float doubletTapTime = 0.2f;
    public bool shadowMode = false;
    public GameManager gm;
    [SerializeField] float timer = 0f;
    [SerializeField] float doubleTaptTimer = 0f;
    private bool duringTouch;
    private bool firstTapped = false;
    private StepUI Steps;
    public bool isSkiping;
    public enum motionState{tap,hold,swipe,none};
    public motionState currentState;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        Steps = GameObject.Find("StepUI").GetComponent<StepUI>();
    }
    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
        #region Mobile Inputs

        if (Input.touches.Length > 0)//there are touching going on in THIS FRAME
        {
            switch (Input.touches[0].phase)
            {
                case (TouchPhase.Began)://prevFrame no touch and curFrame touched

                    duringTouch = true;
                    isSkiping = false;
                    timer = 0;
                    swipeDelta = Vector2.zero;
                    currentState = motionState.tap;
                    startTouch = Input.touches[0].position;
                    

                    break;
                case (TouchPhase.Stationary)://prev and cur both touched, touchlocation the same
                    if (timer <= 0.2f)
                    {
                        timer += Time.deltaTime;
                        if (timer >= 0.08)
                        {
                            isSkiping = true;
                        }
                        
                    }
                    else
                    {
                        if (duringTouch != false)
                        {
                            currentState = motionState.hold;
                            duringTouch = false;
                            Steps.StepLeft -= 1;
                            isSkiping = false;
                            gm.Skip();
                        }

                    }
                    break;
                case (TouchPhase.Moved)://prev and cur both touched, touchlocation changed
                    swipeDelta = Input.touches[0].position - startTouch;
                    if (swipeDelta.magnitude > 85 && duringTouch != false)
                    {
                        duringTouch = false;
                        currentState = motionState.swipe;
                        float x = swipeDelta.x;
                        float y = swipeDelta.y;
                        if (Mathf.Abs(x) > Mathf.Abs(y))
                        {
                            if (x < 0)
                            {
                                swipeLeft = true;
                                print("moved");
                            }
                            else if (x > 0)
                            {
                                swipeRight = true;
                                print("moved");
                            }
                        }
                        else
                        {
                            if (y < 0)
                            {
                                swipeDown = true;
                                print("moved");
                            }
                            else if (y > 0)
                            {
                                swipeUp = true;
                                print("moved");
                            }
                        }

                        if (shadowMode)
                            shadowMode = false;
                    }
                    break;


                default://cancelled/ended, most possibly prev touched and cur not touched/lifted
                    currentState = motionState.none;
                    isSkiping = false;
                    if (duringTouch) { 
                        if (firstTapped != true)//potentially the first tap of the double tap just ended
                        {
                            print("first tap");
                            firstTapped = true;//record the first tap
                            doubleTaptTimer = 0f;//start timer
                            duringTouch = false;
                        }
                        else {

                            print("second tap");
                            print("shadow" + shadowMode);
                            //shadowMode = !shadowMode;
                            shadowMode = true;
                            duringTouch = false;
                            firstTapped = false;
                        }

                    }


                    break;

            }
        }

        if(firstTapped)
            doubleTaptTimer += Time.deltaTime;

        if (doubleTaptTimer > 0.5f)//no more double tap possible
        {
            firstTapped = false;
            doubleTaptTimer = 0f;
        }
    }
        #endregion

    public bool Tap { get{ return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}
