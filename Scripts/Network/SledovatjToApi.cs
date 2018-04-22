using SocketIO;
using System.Collections;
using UnityEngine;

public class SledovatjToApi : MonoBehaviour {

    public SocketIOComponent socket;

    // Used to send the possition to server
    public void NeedMoveSledovanie(string id)
    {
        Debug.Log("Users click on user with id to server: " + ApiConnection.IdFormatter(id));
        // Sending move action to a server
        //ApiConnection.id);
        socket.Emit("sledovanie", new JSONObject(ApiConnection.IdFormatter(id)));
        //socket.Emit("sledovanie", ApiConnection.IdFormatter(id));
    }
}
