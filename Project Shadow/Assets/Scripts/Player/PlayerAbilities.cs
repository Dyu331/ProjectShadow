using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    [HideInInspector]
    public bool inShadow;

    [HideInInspector]
    public bool detected;

    public GameObject strikeUI;

    public bool strike;

    private GameObject enemyToHit;

    public int energy;
    public int strikeCost;
    public int shadowCost;

    public Slider energySlider;
    private bool canAction = true;

    private MotionDetection MotionDetection;

    public GameObject shadowUI;

    private bool strikeActive = false;

    AudioSource audioSource;

    [SerializeField] AudioClip stabSound;
    [SerializeField] AudioClip stepSound;
    [SerializeField] AudioClip gemPickupSound;
    [SerializeField] AudioClip shadowSound;

    //[HideInInspector]
    public bool bribe = false;
    bool prevShadow = false;

    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MotionDetection = GameObject.Find("UICanvas").GetComponent<MotionDetection>();
        col = GetComponent<Collider>();
        //energySlider = GameObject.FindGameObjectWithTag("EnergySlider").GetComponent<Slider>();
        energySlider.maxValue = energy;
    }

    // Update is called once per frame
    void Update()
    {

        if (!bribe)
        {
            energySlider.value = energy;
            if (energy <= 0)
            {
                canAction = false;
            }

            StrikeCheck();

            if (strike)
            {
                energy -= strikeCost;
                Strike(enemyToHit);
                audioSource.clip = stabSound;
                audioSource.Play();
                Debug.Log("Played stab sound");
                

            }

            prevShadow = inShadow;

            if (MotionDetection.shadowMode)
            {
                EnterShadow();
                
            }

            else
            {
                ExitShadow();
            }
        }
    }

    public void EnterShadow()
    {
        if (!inShadow && canAction)
        {
            energy -= shadowCost;
            Debug.Log("shadow");
            shadowUI.SetActive(true);
            col.enabled = false;
            inShadow = true;
            audioSource.clip = shadowSound;
            audioSource.Play();
            Debug.Log("played shadow sound");
        }
    }

    public void ExitShadow()
    {
        if (inShadow)
        {
            Debug.Log("aaaagg");
            shadowUI.SetActive(false);
            col.enabled = true;
            inShadow = false;
            audioSource.clip = shadowSound;
            audioSource.Play();
            Debug.Log("played shadow sound");
        }
    }

    public void StrikeCheck()
    {
        strikeActive = false;
        int strikeInt = 0;

        if (!detected && canAction)
        {
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 1f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1f, Color.yellow);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
            {
                GameObject go = hit.transform.gameObject;

                if (!strikeActive)
                {
                    if (go.CompareTag("Enemy"))
                    {
                        strikeActive = true;
                        enemyToHit = go;
                        strikeInt++;
                    }
                    else
                    {
                        strikeActive = false;
                    }
                }

            }


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1f))
            {
                GameObject go = hit.transform.gameObject;

                if (!strikeActive)
                {
                    if (go.CompareTag("Enemy"))
                    {
                        strikeActive = true;
                        enemyToHit = go;
                        strikeInt++;
                    }
                    else
                    {
                        strikeActive = false;
                    }
                }

            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1f))
            {
                GameObject go = hit.transform.gameObject;

                if (!strikeActive)
                {
                    if (go.CompareTag("Enemy"))
                    {
                        strikeActive = true;
                        enemyToHit = go;
                        strikeInt++;
                    }
                    else
                    {
                        strikeActive = false;
                    }
                }

            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1f))
            {
                GameObject go = hit.transform.gameObject;

                if (!strikeActive)
                {
                    if (go.CompareTag("Enemy"))
                    {
                        strikeActive = true;
                        enemyToHit = go;
                        strikeInt++;
                    }
                    else
                    {
                        strikeActive = false;
                    }
                }

            }
        }

        if (strikeInt > 0 && energy > strikeCost)
        {
            strikeUI.SetActive(true);
        }
        else
        {
            strikeUI.SetActive(false);
        }
    }

    public void Strike(GameObject enemy)
    {
        EnemyMain enemyScript = enemy.GetComponent<EnemyMain>();

        enemyScript.Die();

        strike = false;
        strikeActive = false;
    }
}