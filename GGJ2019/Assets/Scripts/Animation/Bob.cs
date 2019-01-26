using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {

	public float Speed = 1.0f;
	public float Distance = 1.0f;
    public float Offset = 0.0f;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		this.startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = startPosition
            + new Vector3(0, this.Distance * Mathf.Sin(Time.time * this.Speed + this.Offset), 0);
	}
}
