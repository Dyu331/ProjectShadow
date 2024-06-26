using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TestMovement : MonoBehaviour
{
    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero;
    float speed = 5f;
    bool canMove;
    float rayLength = 1f;



    //here difine the direciton

    Vector3 nextPos, destination, direction;

    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = transform.position;

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,destination,speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("w");
            nextPos = Vector3.forward;
            canMove = true;

            currentDirection = up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("s");

            nextPos = Vector3.back;
            canMove = true;

            currentDirection = down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("a");

            nextPos = Vector3.left;
            currentDirection = left;
            canMove = true;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("d");

            nextPos = Vector3.right;
            currentDirection = right;
            canMove = true;
        }
        if (Vector3.Distance(destination,transform.position)<= 0.00001f)
        {

            transform.localEulerAngles = currentDirection;
            if (canMove)
            {
                if (Valid())
                {
                    destination = transform.position + nextPos;
                    canMove = false;
                }
            }
        }

    }
    bool Valid()
    {
        Ray myRay = new Ray(transform.position + new Vector3(0,0.25f,0),transform.forward);
        RaycastHit Hit;
        Debug.DrawRay(myRay.origin,myRay.direction, Color.red);
        if (Physics.Raycast(myRay,out Hit,rayLength))
        {
            if (Hit.collider.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }
}
