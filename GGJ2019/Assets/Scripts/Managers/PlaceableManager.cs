using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceableManager : MonoBehaviour
{
    public GameObject[] placeables;

    public float cooldown;

    public float cooldownTimer;

    private EventSystem _eventSystem;

    private bool _placed;

    private GameObject _instance;

    void OnEnable()
    {
        //Fetch the current EventSystem. Make sure your Scene has one.
        _eventSystem = EventSystem.current;
    }

    void Update() {//Check if there is a mouse click


        if (_placed == true) {
            this.cooldownTimer += Time.deltaTime;
            

            if (this.cooldownTimer > this.cooldown)
            {
                this.cooldownTimer = 0;
                this._placed = false;
            }  
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Send a ray from the camera to the mouseposition
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Create a raycast from the Camera and output anything it hits
            if (Physics.Raycast(ray, out hit)) {
                //Check the hit GameObject has a Collider
                if (hit.collider != null)
                {
                    //Click a GameObject to return that GameObject your mouse pointer hit
                    GameObject gameObject = hit.collider.gameObject;

                    //Set this GameObject you clicked as the currently selected in the EventSystem
                    _eventSystem.SetSelectedGameObject(gameObject);

                    if (gameObject.tag == "Road") {

                        Debug.Log("TEST!!!!");

                        if (cooldownTimer == 0) {
                            this._placed = true;
                            GameObject placeable = Instantiate(this.placeables[0], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.25f, gameObject.transform.position.z), Quaternion.identity);
                            placeable.transform.parent = GameObject.Find("Obstacles").transform;
                        }               
                    }
                }
            }
        }
    }
}
