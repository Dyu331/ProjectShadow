using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Test : MonoBehaviour
{

    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        Grid__ grid = new Grid__(4, 2, 1f, sphere);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
