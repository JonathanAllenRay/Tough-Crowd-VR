using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script borrowed from Megan Johns (who if you're reading this, is probably you)

public class pickupPhysics : MonoBehaviour {

    private bool rightCanGrab;
    private bool leftCanGrab;
    private bool rightHolding;
    private bool leftHolding;
    private GameObject myLeftHand;
    private GameObject myRightHand;

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("HTC_VIU_RightTrigger") > 0 && rightCanGrab)
        {
            transform.parent = myRightHand.transform;
            rightHolding = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
        if (Input.GetAxis("HTC_VIU_LeftTrigger") > 0 && leftCanGrab)
        {
            transform.parent = myLeftHand.transform;
            leftHolding = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
        if (Input.GetAxis("HTC_VIU_RightTrigger") == 0 && rightHolding)
        {
            transform.parent = null;
            rightHolding = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(myRightHand.GetComponent<HandForce>().handForce * 5000);
        }
        if (Input.GetAxis("HTC_VIU_LeftTrigger") == 0 && leftHolding)
        {
            transform.parent = null;
            leftHolding = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(myLeftHand.GetComponent<HandForce>().handForce * 5000);
        }
        rightCanGrab = false;
        leftCanGrab = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "RightHand")
        {
            myRightHand = other.gameObject;
            rightCanGrab = true;
        }
        if (other.tag == "LeftHand")
        {
            myLeftHand = other.gameObject;
            leftCanGrab = true;
        }
    }
}
