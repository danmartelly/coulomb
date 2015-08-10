using UnityEngine;
using System.Collections;

public class bucketGoal : MonoBehaviour {
	public TextMesh winText;

	void Start()
	{
		winText.text = "";
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {

			winText.text = "you win!";
		}
	}
}
