﻿using SocketIO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaspawnitj : MonoBehaviour {

    //Refrence to local player
    public GameObject LocalPlayer;


    // Creating public object "igrokPrefab"
    public GameObject igrokPrefab;

    // Refrence to socket
    public SocketIOComponent socket;

    // Make the dictionary with users 
    //Dictionary<string, GameObject> users;
    Dictionary<string, GameObject> users = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject WhereIsClient(string id)
    {
        // return users with Id as the key
        return users[id];
    }

    //
    public GameObject ZaspawnitjIgroka(string clientid)
    {
        // Create the object when user "zaspawnilosj"
        var user = Instantiate(igrokPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Set refrence to localplayer
        //user.GetComponent<PlayerClick>().LocalPlayer = LocalPlayer;
        user.GetComponent<PlayerClick>().sledovanijeLocalPlayer = LocalPlayer.GetComponent<Sledovanije>();
        //
        user.GetComponent<SledovatjToApi>().socket = socket;
        // set the id in api id
        user.GetComponent<ApiId>().clientID = clientid;
        // Add user to dictionary
        users.Add(clientid, user);

        // Return the user
        return user;

    }

    internal void Delete(string id)
    {
        var user = users[id];
        // Delete user from list and destroy player
        Destroy(user);
        //users.Remove(obj.data["id"].ToString());
        users.Remove(id);
    }
}
