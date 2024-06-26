using UnityEngine.Audio;
using System;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {

    [SerializeField] AudioClip[] clips; //[0] = detected, [1] = bribed
        
    private PlayerAbilities player;

    public AudioSource source;

    bool prevDetection = false;
    bool prevBribe = false;

    // Start is called before the first frame update
   
    void Update ()
    {


        if (GetComponent<EnemyMain>().detected && !prevDetection)
        {
            source.clip = clips[0];
            source.Play();
            Debug.Log("played detection");
           
        }
        prevDetection = player.detected;

        if (GetComponent<EnemyMain>().bribed && !prevBribe) {
            source.clip = clips[1];
            source.Play();
            Debug.Log("bribe");
        }
        prevDetection = GetComponent<EnemyMain>().detected;
        prevBribe = GetComponent<EnemyMain>().bribed;


    }

    void Start ()
    {
        source = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerAbilities>() ;
    }


}
