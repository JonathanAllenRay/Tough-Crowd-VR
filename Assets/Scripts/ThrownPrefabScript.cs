using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownPrefabScript : MonoBehaviour
{

    public int lifetime;
    public int damage;
    public bool primed;
    public bool beenTouched;
    public ParticleSystem ps;
    private GameObject sb;
    public GameObject playah;

    // Use this for initialization
    void Start()
    {
        beenTouched = false;
        Invoke("CleanObject", lifetime);
        GameObject[] temp = GameObject.FindGameObjectsWithTag("HeartBoard");
        playah = GameObject.Find("PlayerSphere");
        sb = temp[0];
        Invoke("primeIt", 2.5f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
        {
            primed = false;
            if (!beenTouched)
            {
                lifetime += 10;
                beenTouched = true;
            }
        }
        if ((other.gameObject.CompareTag("MainCamera") || other.gameObject.CompareTag("Player")) && primed)
        {
            Debug.Log("PLAYER HIT");
            GetComponent<Renderer>().enabled = false;
            if (ps != null)
            {
                //Instantiate(ps, transform.position, transform.rotation);
            }
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Invoke("CleanObject", 0.5f);
            other.GetComponent<PlayerHitReactions>().playerHealth -= damage;
            sb.GetComponent<ScoreboardHeart>().UpdateHealth(other.GetComponent<PlayerHitReactions>().playerHealth);
        }
        else if ((other.gameObject.CompareTag("Audience") && !primed))
        {
            Animator ani = other.GetComponent<Animator>();
            ani.SetTrigger("Hit");
            Debug.Log("AUDIENCE HIT");
            GetComponent<Renderer>().enabled = false;
            if (ps != null)
            {
                //Instantiate(ps, transform.position, transform.rotation);
            }
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            playah.GetComponent<PlayerHitReactions>().playerHealth += 5;
            sb.GetComponent<ScoreboardHeart>().UpdateHealth(other.GetComponent<PlayerHitReactions>().playerHealth);
            Invoke("CleanObject", 0.5f);
        }
    }

    void CleanObject()
    {
        Destroy(gameObject);
    }

    void primeIt()
    {
        primed = false;
    }
}
