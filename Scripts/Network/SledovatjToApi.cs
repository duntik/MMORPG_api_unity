using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledovatjToApi : MonoBehaviour {

    public SocketIOComponent socket;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Used to send the possition to server
    public void NeedMove(string clientID)
    {
        Debug.Log("Users click on user with id to server: " + ApiConnection.IdFormatter(clientID));
        // Sending move action to a server
        socket.Emit("sledovanie", new JSONObject(ApiConnection.IdFormatter(clientID)));
    }
}
