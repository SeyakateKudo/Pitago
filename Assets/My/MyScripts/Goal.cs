using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    Animator anim;
    public GameObject flag;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        flag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            flag.SetActive(true);
            anim.SetBool("IsGoal", true);
        }
    }

}