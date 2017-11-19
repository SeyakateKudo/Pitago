using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustManager : RevAirTap
{

    public GameObject adj;

    public void CreateModeController()
    {
       
        adj.SetActive(false);
        
    }


    public void AdjustModeController()
    {
     
        adj.SetActive(true);
    
    }

    // Use this for initialization
    void Start () {
        /*RevAirTap rev = new RevAirTap();
        rev.set_adjustmode = false;
        rev.adjust.SetActive(false);*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}



/* if (rev.set_adjustmode == true)
        {
          adj.SetActive(true);
        }
        else if (rev.set_adjustmode == false)
        {
          //  rev.adjust.SetActive(false);
        }*/
