using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Track when user click right button
        if (Input.GetButtonDown("Fire2"))
            // if click, call function
            NazhalKnopku();
	}

    // called if user click right button
    private void NazhalKnopku()
    {
        // adding the mause possition to mapAray
        var mapAray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(mapAray);
        RaycastHit nazhal = new RaycastHit();
       // check if user click then ...
        if (Physics.Raycast (mapAray, out nazhal))
        {
            ////Debug.Log(nazhal.collider.gameObject.name);
            //var GroundClick = nazhal.collider.gameObject.GetComponent<GroungClick>();
            var itemWitchClicked = nazhal.collider.gameObject.GetComponent<ItemToClick>();
            // Give the point of interseption where user click 
            itemWitchClicked.ClickToSomthing(nazhal);
        }

    }
}
