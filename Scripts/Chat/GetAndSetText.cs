using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAndSetText : MonoBehaviour {

    public InputField chatmessage;
    public Text usermessage;

    public void setget()
    {
        usermessage.text = chatmessage.text;

    }


}
