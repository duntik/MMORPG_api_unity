using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersClick : MonoBehaviour, ItemToClick {
    public void ClickToSomthing(RaycastHit nazhal)
    {
        Debug.Log("FOLLOWING" + nazhal.collider.gameObject.name);
    }

}
