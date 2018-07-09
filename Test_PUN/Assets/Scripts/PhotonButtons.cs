using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour {

    public PHandler pHandler;
    public InputField createRoomInput;
    public InputField joinRoomInput;


    public void OnClickCreateRoom()
    {
        pHandler.createNewRoom();
    }

    public void OnClickJoinRoom()
    {
        pHandler.joinOrCreateRoom();

    }



    private void OnLeftRoom()
    {

    }
}
