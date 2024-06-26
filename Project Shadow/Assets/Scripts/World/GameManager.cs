using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int turn = 1;

    public bool playerTurn = true;

    private PlayerAbilities player;
    private GameObject[] enemies;

    public GameObject screenShade;

    private MotionDetection MotionDetection;
    public GameObject stabButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        MotionDetection = GameObject.Find("UICanvas").GetComponent<MotionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(enemies.Length);

        if (turn % 2 == 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyMain>().Idle();
            }
        }*/
    }

    public void EnterShadow()
    {
        Debug.Log("press");
        player.EnterShadow();
    }

    public void Strike()
    {
        Debug.Log("strike");

        if (player.energy > player.strikeCost)
            player.strike = true;
    }

    public void Skip()
    {
        turn++;
        playerTurn = false;
    }
}
