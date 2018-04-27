using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class ApiConnection : MonoBehaviour {


    // Socket Refrence Created
    static SocketIOComponent socket;

    // Creating public object "igrokPrefab"
    //public GameObject igrokPrefab;

    // Creating object with local player
    public GameObject LocalPlayer;

    // Make the dictionary with users 
    //Dictionary<string, GameObject> users;

    // Refrence to Zaspawnitj
    public Zaspawnitj zaspawnitjj;


    void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        // callback to reg local player
        socket.On("ukazanie", OnUkazanie);
        // callback for zaspawnitj, to show players
        socket.On("zaspawnitj", OnZaspawnitj);
        // callback for dvizenie, to move player 
        socket.On("dvizenie", OnDvizhenie);
        // callback for sledovanie, to run for player 
        socket.On("sledovanie", OnSledovanie);
        // callback to delete player
        socket.On("deleteplayer", OnDelete);
        // callback to see currentpossition of user
        socket.On("onlineposition", OnOnlinePosition);
        // callback for action on client side
        socket.On("newonlinepossition", OnNewOnlinePosition);
        // callback for attacks
        socket.On("atakuet", OnAtakuet);

        // Instantiate the dictionary with users 
        //users = new Dictionary<string, GameObject>();
	}

    private void OnUkazanie(SocketIOEvent obj)
    {
        Debug.Log("Adding the local player: " + obj.data);
        // call the function to register player
        // passing id and refrence to local player
        //zaspawnitjj.DobavitjIgroka(obj.data["id"].ToString(), LocalPlayer);
        zaspawnitjj.DobavitjIgroka(obj.data["id"].str, LocalPlayer);
    }
    //
    private void OnSledovanie(SocketIOEvent obj)
    {
        Debug.Log("Zapeos sledovanija" + obj.data);
        // use dictionary to refrence id with game object
        //var user = users[playerID];
        //var user = zaspawnitjj.WhereIsClient(obj.data["id"].ToString());
        var user = zaspawnitjj.WhereIsClient(obj.data["id"].str);
        //var user = zaspawnitjj.WhereIsClient(obj.data["id"].str);
        // get the clelj
        //var celj = zaspawnitjj.WhereIsClient(obj.data["clientID"].ToString());
        var celj = zaspawnitjj.WhereIsClient(obj.data["clientID"].str).transform;
        // get the refrence to sledovanie
        var sledovanie = user.GetComponent<Sledovanije>();
        // set the celj na sledovanie
        Debug.Log("AAAAAAAAA" + obj.data["id"].str);
        Debug.Log("BBBBBBBBB" + obj.data["clientID"].str);
        Debug.Log("CCCCCCCCC" + user);
        Debug.Log("DDDDDDDDD" + celj);
        Debug.Log("DDDDDDDDD" + celj.transform);
        sledovanie.celj = celj;
    }

    //

    private void OnNewOnlinePosition(SocketIOEvent obj)
    {
        Debug.Log("NewOnlinePossition: " + obj.data);
        // Putting x and y to vector 3 possition
        var pos = new Vector3(GetFloatFromJson(obj.data, "x"), 0, GetFloatFromJson(obj.data, "y"));
        //Debug.Log("possition: " + possition);
        // Refrence playerId with id from data
        //var playerID = users[obj.data["id"].ToString()];
        //var playerID = zaspawnitjj.WhereIsClient(obj.data["id"].ToString());
        var playerID = zaspawnitjj.WhereIsClient(obj.data["id"].str);
        // Refrence player and change possition from transform
        playerID.transform.position = pos;

    }

    // To get the possition

    private void OnOnlinePosition(SocketIOEvent obj)
    {
        Debug.Log("Requesting the position");
        socket.Emit("newonlinepossition", new JSONObject(VectorToJson(LocalPlayer.transform.position)));
    }

    // To delete the user

    private void OnDelete(SocketIOEvent obj)
    {
        Debug.Log("deleted player: " + obj.data);
        //Set user = to user ID from users dictionary
        //var user = users[obj.data["id"].ToString()];
        //var id = obj.data["id"].ToString();
        var id = obj.data["id"].str;
        //var user = users[id];
        //// Delete user from list and destroy player
        //Destroy(user);
        ////users.Remove(obj.data["id"].ToString());
        //users.Remove(id);
        zaspawnitjj.Delete(id);
    }

    // To move objects

    private void OnDvizhenie(SocketIOEvent obj)
    {
        Debug.Log("Player on Dvizhenie" + obj.data);
        // Get the possition of x
        //var x = GetFloatFromJson(obj.data, "x");
        //Debug.Log("x: " + x);
        // Putting x and y to vector 3 possition
        var pos = new Vector3(GetFloatFromJson(obj.data, "x"), 0, GetFloatFromJson(obj.data, "y"));
        //Debug.Log("possition: " + possition);

        // Refrence playerId with id from data
        //var playerID = obj.data["id"].ToString();

        // use dictionary to refrence id with game object
        //var user = users[playerID];
        //var user = zaspawnitjj.WhereIsClient(obj.data["id"].ToString());
        var user = zaspawnitjj.WhereIsClient(obj.data["id"].str);
        // Get refrence to navigate position to a user
        var positionNavigator = user.GetComponent<PositionNavigator>();
        // Navigate to possition witch we get
        positionNavigator.PlayerNavigation(pos);
        //Debug.Log(playerID);
    }

        private void OnAtakuet(SocketIOEvent obj)
    {
        Debug.Log("Attack Player: " + obj.data);
        // call the function to register player
        // passing id and refrence to local player
        //zaspawnitjj.DobavitjIgroka(obj.data["id"].ToString(), LocalPlayer);
        ClickPlayer.player.atakuet.helth -10;
        attajuet.(obj.data["id"].str, LocalPlayer);
    }


    // To generete object at start

    private void OnZaspawnitj(SocketIOEvent obj)
    {
        Debug.Log("Zaspawnilosj!" + obj.data);
        // Create the object when user "zaspawnilosj"
        //var user = Instantiate(igrokPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //var user = zaspawnitjj.ZaspawnitjIgroka(obj.data["id"].ToString());
        var user = zaspawnitjj.ZaspawnitjIgroka(obj.data["id"].str);
        // check the player possition, when player spawned, dont need request the possition
        if (obj.data["x"])
        {
            // Putting x and y to vector 3 possition
            var posM = new Vector3(GetFloatFromJson(obj.data, "x"), 0, GetFloatFromJson(obj.data, "y"));
            //Debug.Log("posM is:" + posM);
            // Get refrence to navigate position to a user
            var positionNavigator = user.GetComponent<PositionNavigator>();
            // Navigate to possition witch we get
            positionNavigator.PlayerNavigation(posM);
            // New element when new player connects
        }
        //users.Add(obj.data["id"].ToString(), user);
        //Determine that
        //Debug.Log("Count: " + users.Count);
    }

    // when connected

    private void OnConnected(SocketIOEvent obj)
    {
        Debug.Log("connected");
    }

    public static string VectorToJson(Vector3 vector)
    {
        return string.Format(@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);
    }

    float GetFloatFromJson(JSONObject data, string key)
    {
        // Get the possition from json
        //return float.Parse(data[key].ToString().Replace("\"", ""));
        //return float.Parse(data[key].ToString());
        return float.Parse(data[key].str);
    }

    public static string IdFormatter(string clientID)
    {
        //return string.Format(@"{{""id"":""{0}""}}", clientID);
        return string.Format(@"{{""clientID"":""{0}""}}", clientID);
    }
}
