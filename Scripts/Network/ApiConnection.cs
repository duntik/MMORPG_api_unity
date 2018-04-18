using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class ApiConnection : MonoBehaviour {

    // Socket Refrence Created
    static SocketIOComponent socket;

    // Creating public object "igrokPrefab"
    public GameObject igrokPrefab;


    void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        // callback for zaspawnitj
        socket.On("zaspawnitj", OnZaspawnitj);

	}

    private void OnZaspawnitj(SocketIOEvent obj)
    {
        Debug.Log("Zaspawnilosj!");
        // Create the object when user "zaspawnilosj"
        Instantiate(igrokPrefab);
    }

    private void OnConnected(SocketIOEvent obj)
    {
        Debug.Log("connected");
        socket.Emit("dvizenie");
    }

}
