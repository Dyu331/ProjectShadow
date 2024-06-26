using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BribeDetect : MonoBehaviour
{
    public PlayerAbilities player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.bribe)
            {
                //next level
                Debug.Log("success");
            }
            else
            {
                //failure
                Debug.Log("fail");
            }
        }
    }
}
