using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PositionNavigator : MonoBehaviour {

    // Refrence to navmesh inside the player
    NavMeshAgent player;

	// Use this for initialization
	void Awake () {
        //Search gameobjects where this script attached
        //Find component of NavMeshAgent and set to player
        player = GetComponent<NavMeshAgent>();
	}

    // Used for animation, update the OnDistance condition
    void Update()
    {
        //Applaying distance to animation, Run --> Idle
        GetComponent<Animator>().SetFloat("WhenRunDis", player.remainingDistance);
    }

    // Used to navigete gameobjects
    public void PlayerNavigation(Vector3 pos) {
        // Move gameobject to possition
        player.SetDestination(pos);
	}
}
