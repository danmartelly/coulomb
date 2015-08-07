using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalController : MonoBehaviour {

	public float rotateSpeed = 1;
	public Text winText;

	void Start()
	{
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0f, rotateSpeed, 0f));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log ("you win");
			winText.text = "You Win!";
		}
	}
}
