﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //calculate how far away from the camera the player is
        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's,
        //but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}