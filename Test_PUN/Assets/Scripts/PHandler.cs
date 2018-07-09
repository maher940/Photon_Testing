using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PHandler : MonoBehaviour {

    public PhotonButtons photonB;
    public GameObject mainPlayer;
    private void Awake()
    {
        PhotonNetwork.sendRate = 30;
        PhotonNetwork.sendRateOnSerialize = 20;
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void createNewRoom()
    {
        
            PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
        
    }

    public void joinOrCreateRoom()
    {
        //PhotonNetwork.JoinRoom(joinRoomInput.text);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);
    }

    public void moveScene()
    {
        PhotonNetwork.LoadLevel("mainGame");
    }
    private void OnJoinedRoom()
    {
        moveScene();
        Debug.Log("We are conecting to the room");
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("here:");
        if(scene.name == "mainGame")
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);
        //PhotonNetwork.player.ID
        Debug.Log("Player Id" + PhotonNetwork.player.ID);

    }
}
