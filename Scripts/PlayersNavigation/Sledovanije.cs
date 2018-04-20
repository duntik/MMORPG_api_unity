using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sledovanije : MonoBehaviour {

    // Refrence to what we follow
    public Transform celj;

    // Distance where player stopping to run to another player
    public float nebegi = 2;

    // make frequency for scaning
    public float chastotaScanitovanija = 0.3f;

    // get the point of last scaning
    float posledneeScanirovanie = 0;

    // Refrence to navigator class
    PositionNavigator positionF;

	// Use this for initialization
	void Start () {
        // set the refrence
        positionF = GetComponent<PositionNavigator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - posledneeScanirovanie > chastotaScanitovanija && celj && isNotInRange())
        {
            Debug.Log("scanbing nav path");
            // sending to navigate
            positionF.PlayerNavigation(celj.position);
        }
	}

    private bool isNotInRange()
    {
        // Getting the position of user witch follow
        var distance = Vector3.Distance(celj.position, transform.position);
        return distance > nebegi;
    }
}
