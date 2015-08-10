using UnityEngine;
using System.Collections;

public class wasdMove : MonoBehaviour {

	float speed = 5.0f; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")) {
			transform.Translate (new Vector3(0, 0, 1) * Time.deltaTime * speed, Space.World);
		}
		if (Input.GetKey ("s")) {
			transform.Translate (new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);
		}
		if (Input.GetKey ("a")) {
			transform.Translate (new Vector3(-1, 0, 0) * Time.deltaTime * speed, Space.World);
		}
		if (Input.GetKey ("d")) {
			transform.Translate (new Vector3(1, 0, 0) * Time.deltaTime * speed, Space.World);
		}
	}
}
