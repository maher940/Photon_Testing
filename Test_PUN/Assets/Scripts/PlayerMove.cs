﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Photon.MonoBehaviour {

    public bool devTesting = false;
    public PhotonView photonView;

    public float moveSpeed = 5f;

    public float jumpForce = 800f;

    private Vector3 selfPos;

    private GameObject sceneCam;

    public GameObject plCam;

    private void Awake()
    {
        if(!devTesting && photonView.isMine)
        {
            sceneCam = GameObject.Find("Main Camera");
            sceneCam.SetActive(false);
            plCam.SetActive(true);
        }
    }

    private void Update()
    {
        if (!devTesting)
        {
            //will control all if ismine not there
            if (photonView.isMine)
            {
                checkInput();
            }
            else
            {
                smoothNetMovement();
            }
        }
        else
        {
            checkInput();
        }
    }

    private void checkInput()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    private void smoothNetMovement()
    {
        transform.position = Vector3.Lerp(transform.position, selfPos, Time.deltaTime * 8);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.SendNext(transform.position);

        }
        else
        {
            selfPos = (Vector3)stream.ReceiveNext();
        }
    }
}
