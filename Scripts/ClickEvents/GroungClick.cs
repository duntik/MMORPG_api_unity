using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroungClick : MonoBehaviour, ItemToClick{

    public GameObject gameUser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void ClickToSomthing(RaycastHit nazhal) {
        var posToNavigate = gameUser.GetComponent<PositionNavigator>();
        // Get Server Possition of moving
        var serverPosToNavigate = gameUser.GetComponent<MovingToApi>();
        // Sending pos to PositionNavigator
        posToNavigate.PlayerNavigation(nazhal.point);
        // Sending possition to NeedMove function 
        serverPosToNavigate.NeedMove(nazhal.point);

    }
}
