using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool patrol;

    public int lookDistance;

    Vector3 up = Vector3.zero,
    currentDir = Vector3.zero;

    Vector3 nextPos, destination;

    public float speed = 5;

    bool canMove = true;

    private bool isChasing;

    public enum EnemyState
    {
        Idle, Patrol, Chase
    }
    [SerializeField] EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        currentDir = up;
        nextPos = Vector3.forward;
        destination = transform.position;

        if (!patrol)
            state = EnemyState.Idle;
        else
            state = EnemyState.Patrol;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(canMove);
        if (state == EnemyState.Patrol)
            Patrol();
        else if (state == EnemyState.Idle)
            Look();
        else if (state == EnemyState.Chase)
            Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector3.Distance(destination, transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentDir;

            if (canMove)
            {
                destination = transform.position + nextPos;
            }
        }
        canMove = false;
    }

    void Look()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lookDistance, Color.yellow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            GameObject go = hit.transform.gameObject;

            if (go.CompareTag("Player"))
            {
                //canMove = true;
                destination = hit.transform.position;

                state = EnemyState.Chase;
            }
            Debug.Log("Hit");

            isChasing = true;
        }
    }

    void Patrol()
    {
        //follow preset path between points

        Look();
    }
}