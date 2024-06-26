using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TESTSwipeMovement : MonoBehaviour
{
    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero;
    int moveDirIndex;
    float speed = 5f;
    bool canMove;
    float rayLength = 1f;
    private MotionDetection swipeControl;//remember to change it back to MotionDetection
    public Transform player;
    private StepUI Steps;
    GridScript gridScript;
    

    private PlayerAbilities playerAbilities;

    //here difine the direciton

    Vector3 nextPos, destination, direction;

    void Start()
    {
        Steps = GameObject.Find("StepUI").GetComponent<StepUI>();
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = transform.position;
        gridScript = GameObject.Find("spawner").GetComponent<GridScript>();
        playerAbilities = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>();
        swipeControl = GameObject.Find("UICanvas").GetComponent<MotionDetection>();

    }

    void LateUpdate()
    {
        if (playerAbilities.inShadow == false)
            MovePlayer();
    }

    void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        //gridScript.updateGrid(moveDirIndex, 1);
        

        if (swipeControl.SwipeUp && gridScript.grid.gridArray[(int)gridScript.playerGridPosition.x, (int)gridScript.playerGridPosition.y-1].type != 2)
        {
            Steps.StepLeft -= 1;
            nextPos = Vector3.forward;
            canMove = true;
            moveDirIndex = 8;
            gridScript.MoveGrid(gridScript.playerGridPosition, new Vector3(0, -1, 0));

            currentDirection = up;
        }
        if (swipeControl.SwipeDown && gridScript.grid.gridArray[(int)gridScript.playerGridPosition.x, (int)gridScript.playerGridPosition.y + 1].type != 2)
        {
            Steps.StepLeft -= 1;

            nextPos = Vector3.back;
            moveDirIndex = 2;
            gridScript.MoveGrid(gridScript.playerGridPosition, new Vector3(0, 1, 0));
            canMove = true;

            currentDirection = down;
        }
        if (swipeControl.SwipeLeft && gridScript.grid.gridArray[(int)gridScript.playerGridPosition.x - 1 , (int)gridScript.playerGridPosition.y].type != 2)
        {
            Steps.StepLeft -= 1;

            nextPos = Vector3.left;
            currentDirection = left;
            moveDirIndex = 4;
            gridScript.MoveGrid(gridScript.playerGridPosition, new Vector3(-1, 0, 0));
            canMove = true;

        }
        if (swipeControl.SwipeRight && gridScript.grid.gridArray[(int)gridScript.playerGridPosition.x + 1, (int)gridScript.playerGridPosition.y].type != 2)
        {
            Steps.StepLeft -= 1;
            nextPos = Vector3.right;
            currentDirection = right;
            moveDirIndex = 6;
            gridScript.MoveGrid(gridScript.playerGridPosition, new Vector3(1, 0, 0));
            canMove = true;

        }
        if (swipeControl.Tap)
            Debug.Log("Tap!");
        if (Vector3.Distance(destination, transform.position) <= 0.0001f)
        {

            transform.localEulerAngles = currentDirection;
            if (canMove)
            {

                destination = transform.position + nextPos;
                canMove = false;
            }

        }

    }
}
