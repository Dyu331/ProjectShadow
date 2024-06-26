using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public bool isIdle;
    private int spotTurn = 0;

    public bool patrol;
    public bool detected;
    public bool bribed;

    static List<EnemyMain> allEnemies;

    private GameManager gm;

    [SerializeField]
    private GameObject[] waypoints;
    private int waypointIndex = 0;

    public float speed;
    public int lookDistance;

    private GameObject playerSearch;

    private PlayerAbilities player;

    private bool reachedDestination = false;

    public GameObject deathModel;
    public GameObject deathParticle;

    public GameObject alert;

    private void Awake()
    {
        if (allEnemies == null)
            allEnemies = new List<EnemyMain>();
        allEnemies.Add(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (patrol)
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        if (gm.turn % 2 == 0 || player.bribe)
        {
            if (!turnInProgress)
            {
                TakeTurn();

                bribed = true;
            }
            else if (TurnCompleted())
            {
                gm.turn++;
            }

        }

        if (!player.bribe)
        {
            Guard();
            bribed = false;
        }
        else if (!isIdle)
        {
            Alert(spotTurn + 2);
            Debug.Log(spotTurn);
        }
    }

    static bool turnInProgress = false;
    static void TakeTurn()
    {
        
        turnInProgress = true;
        foreach (EnemyMain enemy in allEnemies)
        {
            enemy.reachedDestination = false;
            enemy.StartCoroutine(enemy.Idle());
        }
    }

    static bool TurnCompleted()
    {
        foreach (EnemyMain enemy in allEnemies)
        {
            if (!enemy.reachedDestination)
            {
                return false;
            }
        }

        turnInProgress = false;
        return true;
    }

    public IEnumerator Idle()
    {
        if (patrol)
        {
            //move between waypoints

            if (waypointIndex < waypoints.Length - 1)
            {


                //Debug.Log(gameObject + "" + waypointIndex);
                while (!reachedDestination){
                    transform.LookAt(waypoints[waypointIndex].transform.position, Vector3.forward);
                    transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex + 1].transform.position, speed * Time.deltaTime);

                    //FindObjectOfType<audioman>().Play("guardstep");

                    if (transform.position == waypoints[waypointIndex + 1].transform.position)
                    {
                        reachedDestination = true;
                        waypointIndex++;
                    }

                    yield return new WaitForEndOfFrame();
                }   
            }
            else if (waypointIndex == waypoints.Length - 1)
            {

                while (!reachedDestination)
                {
                    transform.LookAt(waypoints[0].transform.position, Vector3.forward);
                    transform.position = Vector3.MoveTowards(transform.position, waypoints[0].transform.position, speed * Time.deltaTime);

                    if (transform.position == waypoints[0].transform.position)
                    {
                        reachedDestination = true;
                        waypointIndex = 0;
                        //gm.turn++;
                    }

                    yield return new WaitForEndOfFrame();
                }
            }
        }
    }

    void Guard()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * lookDistance, Color.yellow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, lookDistance))
        {
            if (patrol)
                alert.SetActive(true);

            GameObject go = hit.transform.gameObject;

            if (go.CompareTag("Player"))
            {
                Debug.Log("Spotted");
                spotTurn = gm.turn;
                isIdle = false;
                detected = true;
            }
        }
        else
        {
            alert.SetActive(false);
            detected = false;
        }
    }

    void Alert(int turn)
    {
        if (gm.turn == turn)
        {
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lookDistance, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * lookDistance, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * lookDistance, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * lookDistance, Color.yellow);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookDistance))
            {
                GameObject go = hit.transform.gameObject;

                if (go.CompareTag("Player"))
                {
                    Debug.Log("Kill");
                    Destroy(hit.transform.gameObject, 0.2f);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, lookDistance))
            {
                GameObject go = hit.transform.gameObject;

                if (go.CompareTag("Player"))
                {
                    Debug.Log("Kill");
                    Destroy(hit.transform.gameObject, 0.2f);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, lookDistance))
            {
                GameObject go = hit.transform.gameObject;

                if (go.CompareTag("Player"))
                {
                    Debug.Log("Kill");
                    Destroy(hit.transform.gameObject, 0.2f);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, lookDistance))
            {
                GameObject go = hit.transform.gameObject;

                if (go.CompareTag("Player"))
                {
                    Debug.Log("Kill");
                    Destroy(hit.transform.gameObject, 0.2f);
                }
            }
        }
        else if (gm.turn > turn)
        {
            isIdle = true;
        }
    }

    public void Die()
    {
        //particle effect
        allEnemies.Remove(this);
        Instantiate(deathModel, new Vector3 (transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
        Instantiate(deathParticle, new Vector3 (transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);

        Destroy(gameObject, 0.2f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject, 0.2f);
        }
    }
}