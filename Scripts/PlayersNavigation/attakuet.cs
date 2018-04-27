using System.Collections;
using UnityEngine;

public class Attakuet : MonoBehaviour {

    // Refrence with player
    PlayerClick player;
    // Set the attack area
    public float areaOfAttack;
    // set aTTACK SPEED
    float speed;

    // Use this for initialization
	void Start () {
        player = GetComponent<PlayerClick>();
	}

    void Update () {
        // if player can be hittable
        if(range() && canHit() && !dead()){
           //Debug.Log("get attaed");
            var id = players.player.GetComponent<PlayerClick>();
            ApiConnection.Ubitj(id);
        }
    
    }

}