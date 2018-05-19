using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandScript : MonoBehaviour {

    Animator m_animator;

    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("HTC_VIU_RightTrigger") > 0)
        {
            bool Is_Grab = true;
            bool Is_Release = false;
            m_animator.SetBool("Is_Release", Is_Release);
            m_animator.SetBool("Is_Grab", Is_Grab);
        } else
        {
            bool Is_Grab = false;
            bool Is_Release = true;
            m_animator.SetBool("Is_Release", Is_Release);
            m_animator.SetBool("Is_Grab", Is_Grab);
        }
        

        /*
        if (Input.GetKeyDown("space"))
        {
            bool Is_Grab = true;
            bool Is_Release = false;
            m_animator.SetBool("Is_Release", Is_Release);
            m_animator.SetBool("Is_Grab", Is_Grab);
        }
        if (Input.GetKeyUp("space"))
        {
            bool Is_Grab = false;
            bool Is_Release = true;
            m_animator.SetBool("Is_Release", Is_Release);
            m_animator.SetBool("Is_Grab", Is_Grab);
        }
        */
    }
}
