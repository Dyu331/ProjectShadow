using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipChange : MonoBehaviour
{
    [SerializeField] int thisTip;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.tag == "Player") GameObject.Find("TipBackground").GetComponent<TipScript>().TipNum = thisTip;
    }
}
