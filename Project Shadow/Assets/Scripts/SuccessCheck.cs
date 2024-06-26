using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SuccessCheck : MonoBehaviour


{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject playerObject;
    private void Start()
    {
        //GameObject.FindWithTag("winPanelUI").SetActive(false);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.tag == "Player")
        {
            playerObject.SetActive(false);
            winPanel.SetActive(true);
        }
    }
}
