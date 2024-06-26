using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioman : MonoBehaviour {

    public soudn[] sounds;
    private soudn s; 

    public static audioman instance;

    private PlayerAbilities player;

    private AudioSource audiomanSource;

    // Start is called before the first frame update
    void Awake() {
        audiomanSource = GetComponent<AudioSource>();

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>();

        foreach (soudn sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = s.clip;

            sound.source.volume = s.volume;
            sound.source.pitch = s.pitch;
            sound.source.loop = s.loop;
        }
    }

    void Update ()
    {
        if(player.inShadow && s != null)
        {
            s.source.pitch = 0.2f; 
        } else if (!player.inShadow && s != null)
        {
            s.source.pitch = 1f; 
        }

        if(player.detected)
        {
            audiomanSource.PlayOneShot(ChooseClip("spotted"));
            Debug.Log("shdfzsljvdhbslzdvhbz");
        }

        if(player.strike)
        {
            audiomanSource.PlayOneShot(ChooseClip("stab"));
        }

    }

    void Start ()
    {
    }

    public AudioClip ChooseClip (string name)
    {
        soudn s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
        }
        return s.clip;
    }

}
