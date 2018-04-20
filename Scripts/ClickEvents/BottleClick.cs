using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleClick : MonoBehaviour, ItemToClick
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickToSomthing(RaycastHit nazhal)
    {
        Debug.Log("Get bottle" + nazhal.collider.gameObject.name);
    }
}
