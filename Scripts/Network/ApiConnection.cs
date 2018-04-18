using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class ApiConnection : MonoBehaviour {

    // Socket Refrence Created
    static SocketIOComponent socket;


	void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
	}

    private void OnConnected(SocketIOEvent obj)
    {
        Debug.Log("connected");
        socket.Emit("dvizenie");
    }

}
