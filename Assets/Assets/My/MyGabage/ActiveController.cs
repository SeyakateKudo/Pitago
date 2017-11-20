using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActiveController : RevAirTap
{
    public GameObject _ball;
    public GameObject _trans;
    public Transform _;

    // Use this for initialization
    void Start () {
       // GameObject gameObject = GameObject.Find("TransformController");
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Active()
    {
        _trans = _ball.transform.Find("TransformController").gameObject;
        GameObject gameObject = GameObject.Find("Ball").transform.Find("TransformController").gameObject;
        gameObject.SetActive(true);
    }
       
    public void DisActive()
        {
            GameObject gameObject = GameObject.Find("TransformController");
            gameObject.SetActive(false);
        }
    }

