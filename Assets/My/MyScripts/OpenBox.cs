using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


public class OpenBox : MonoBehaviour, IInputClickHandler
{

    Animator anim;
    public GameObject box;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        anim.SetBool("Isopen", true);
        Destroy(box, 5f);
       
    }

}
