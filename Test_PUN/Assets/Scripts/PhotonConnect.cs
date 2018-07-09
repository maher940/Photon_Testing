using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour {


    public string versionname = "0.1";

    public GameObject sectionView1;
    public GameObject sectionView2;
    public GameObject sectionView3;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionname);
        Debug.Log("Connecting to photon");
    }

	private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We are connected to master");
       

    }

    private void OnJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        
        Debug.Log(" On Join Lobby");
    }

    private void OnDisconnectedFromPhoton()
    {
        if(sectionView1.activeSelf)
        {
            sectionView1.SetActive(false);
        }
        if(sectionView2.activeSelf)
        {
            sectionView2.SetActive(false);
        }
        sectionView3.SetActive(true);
        Debug.Log("Dis from photon");
    }

    private void OnFailedToConnectToPhoton()
    {

    }
}
