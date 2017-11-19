using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActiveController : RevAirTap
{
    public bool setactive; 

    // Use this for initialization
    void Start () {
        GameObject gameObject = GameObject.Find("TransformController");
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnInputActive(InputClickedEventData eventData)
    {
        if (rev.set_adjustmode == true) {
            GameObject gameObject = this.transform.Find("TransformController").gameObject;
            gameObject.SetActive(true);

        }
        else if(rev.set_createmode == true)
        {
            GameObject gameObject = GameObject.Find("TransformController");
            gameObject.SetActive(false);
        }
    }
}
