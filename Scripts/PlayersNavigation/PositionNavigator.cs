using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PositionNavigator : MonoBehaviour {

    // Refrence to navmesh inside the player
    NavMeshAgent player;

	// Use this for initialization
	void Start () {
        //Search gameobjects where this script attached
        //Find component of NavMeshAgent and set to player
        player = GetComponent<NavMeshAgent>();
	}
	
	// Used to navigete gameobjects
	public void PlayerNavigation(Vector3 pos) {
        // Move gameobject to possition
        player.SetDestination(pos);
	}
}
