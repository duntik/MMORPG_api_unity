using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToApi : MonoBehaviour {

    public SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Used to send the possition to server
    public void NeedMove(Vector3 pos)
    {
        Debug.Log("Position to server: " + VectorToJson(pos));
        socket.Emit("dvizenie", new JSONObject(VectorToJson(pos)));
    }

    string VectorToJson(Vector3 vector)
    {
        return string.Format(@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);
    }
}
