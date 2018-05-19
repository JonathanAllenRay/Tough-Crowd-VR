using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPrefab : MonoBehaviour
{

    public GameObject thrownPrefab;
    public bool activeAudience;
    private Vector3 displacement;
    public AudioClip[] clips;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        clips = Resources.LoadAll<AudioClip>("Retro_Sound_Pack/SoundEffects/DrumBeats(8bit)");
        activeAudience = false;
        displacement = gameObject.transform.position + new Vector3(0.0f, 0f, 0.0f);
        InvokeRepeating("tossWrapper", 0.0f, Random.Range(2.0f, 2.5f));
    }

    void tossWrapper()
    {
        if (activeAudience)
        {
            animator.SetTrigger("ThrowThing");
        }
        else if (!activeAudience && Random.Range(0, 15) <= 2)
        {
            animator.SetTrigger("Jump");
        }
        if (Random.Range(0, 15) <= 2)
        {
            AudioSource mySound = GetComponent<AudioSource>();
            mySound.clip = clips[Random.Range(0, clips.Length)];
            mySound.pitch = Random.Range(0.80f, 1.20f);
            mySound.volume = Random.Range(0.35f, 0.45f);
            mySound.Play();
        }
    }

    void toss()
    {
        Vector3 push = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(4, 8), Random.Range(20.0f, 10.0f));
        GameObject prefabObject = Instantiate(thrownPrefab, displacement, transform.rotation);
        prefabObject.GetComponent<Rigidbody>().AddRelativeForce(push, ForceMode.Impulse);
    }
}
