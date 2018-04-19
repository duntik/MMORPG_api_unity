using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour, ItemToClick {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickToSomthing(RaycastHit nazhal)
    {
        Debug.Log("following" + nazhal.collider.gameObject.name);
    }
}
