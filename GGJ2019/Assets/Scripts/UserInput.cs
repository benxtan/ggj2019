using UnityEngine;
using System.Collections;
using RTS;
 
public class UserInput : MonoBehaviour {
 
 
    // Use this for initialization
    void Start () {
    }
 
    // Update is called once per frame
    void Update () {
        MoveCamera();
        // RotateCamera();
    }
 
    private void MoveCamera() {
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;
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
 
        //calculate desired camera position based on received input
        Vector3 origin = Camera.main.transform.position;
        Vector3 destination = origin;
        destination.x += movement.x;
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