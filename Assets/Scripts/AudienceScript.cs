using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceScript : MonoBehaviour {

    Animator Person;

    public GameObject Stars;


    public GameObject PlayerHealthObject;


	// Use this for initialization
	void Start () {
        Person = GetComponent<Animator>();
        Stars.SetActive(false);
        PlayerHealthObject = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Throwable")
        {
            Destroy(other);
            PlayerHealthObject.GetComponent<PlayerHitReactions>().playerHealth += 25;
            Person.SetTrigger("Hit");
            Stars.SetActive(true);
            Invoke("DeleteThePerson", 3);
        }
    }
    void DeleteThePerson()
    {
        Stars.SetActive(false);
        Destroy(this.gameObject);
    }
}
