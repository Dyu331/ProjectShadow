using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepUI : MonoBehaviour
{
    public int StepLeft = 90;
    private TMP_Text Steps;
    // Start is called before the first frame update
    void Start()
    {
        Steps = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Steps.text = "Step:" + StepLeft.ToString();
    }
}
