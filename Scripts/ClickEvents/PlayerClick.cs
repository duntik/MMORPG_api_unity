using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour, ItemToClick {

    // Refrence to local player
    //public GameObject LocalPlayer;
    public Sledovanije sledovanieLocalPlayer;
    // reftence to apiid
    public ApiId apiid;

    // Use this for initialization
    void Start () {
        apiid = GetComponent<ApiId>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickToSomthing(RaycastHit nazhal)
    {
        Debug.Log("following" + nazhal.collider.gameObject.name);

        // Askin to move player on server
        GetComponent<SledovatjToApi>().NeedMoveSledovanie(apiid.clientID);

        //ApiConnection.Follow(apiid.clientID);

        // Tell local player to follow what it's clicked on
        //LocalPlayer.GetComponent<>();
        sledovanieLocalPlayer.celj = transform;
    }
}
