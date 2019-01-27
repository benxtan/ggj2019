﻿using UnityEngine;
using System.Collections;
using RTS;
 
public class UserInput : MonoBehaviour {
     // Use this for initialization
    void Start () {
    }
 
    // Update is called once per frame
    void Update () {
        MoveCamera();
    }
 
    private void MoveCamera() {
        // float xpos = Input.mousePosition.x;
        // float ypos = Input.mousePosition.y;

        Vector3 movement = new Vector3(0,0,0);

        // horizontal camera movement
        if (Input.GetKey(KeyCode.A)) {
            movement.x -= ResourceManager.ScrollSpeed;
        }

        if (Input.GetKey(KeyCode.D)) {
            movement.x += ResourceManager.ScrollSpeed;
        }

        // vertical camera movement
        if (Input.GetKey(KeyCode.W)) {
            movement.z += ResourceManager.ScrollSpeed;
        }

        if (Input.GetKey(KeyCode.S)) {
            movement.z -= ResourceManager.ScrollSpeed;
        }
 
        // //horizontal camera movement
        // if(xpos >= 0 && xpos < ResourceManager.ScrollWidth) {
        //     movement.x -= ResourceManager.ScrollSpeed;
        // } else if(xpos <= Screen.width && xpos > Screen.width - ResourceManager.ScrollWidth) {
        //     movement.x += ResourceManager.ScrollSpeed;
        // }
 
        // //vertical camera movement
        // if(ypos >= 0 && ypos < ResourceManager.ScrollWidth) {
        //     movement.z -= ResourceManager.ScrollSpeed;
        // } else if(ypos <= Screen.height && ypos > Screen.height - ResourceManager.ScrollWidth) {
        //     movement.z += ResourceManager.ScrollSpeed;
        // }
 
        //make sure movement is in the direction the camera is pointing
        //but ignore the vertical tilt of the camera to get sensible scrolling
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0;

        //away from ground movement
        //movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize + 0.5f, 10f);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 0.5f, 1f);
        }

        //calculate desired camera position based on received input
        Vector3 origin = Camera.main.transform.position;
        Vector3 destination = origin;
        destination.x += movement.x;
        destination.y += movement.y;
        destination.z += movement.z;
 
        //if a change in position is detected perform the necessary update
        if(destination != origin) {
            Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
        }
    }
 
    private void RotateCamera() {
        Vector3 origin = Camera.main.transform.eulerAngles;
        Vector3 destination = origin;

        if (Input.GetKey(KeyCode.Q))
        {
            destination.y -= ResourceManager.RotateAmount;
        }


        if (Input.GetKey(KeyCode.E))
        {
            destination.y += ResourceManager.RotateAmount;
        }
 
        //if a change in position is detected perform the necessary update
        if(destination != origin) {
            Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.RotateSpeed);
        }
    }
}