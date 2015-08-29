using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveStrength;
	public float coulombK;
	public float maxSingleForce;
	protected Rigidbody rb;
	protected GameObject[] charges;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		charges = GameObject.FindGameObjectsWithTag ("StaticCharge");
	}

	/* returns force that would be exerted on item at pos '1' */
	protected Vector3 CoulombsForce(Vector3 pos1, Vector3 pos2, float charge1, float charge2)
	{
		Vector3 vec = pos1 - pos2;
		float mag = coulombK * charge1 * charge2 / vec.sqrMagnitude;
		if (mag > maxSingleForce)
			mag = maxSingleForce;
		else if (mag < -maxSingleForce)
			mag = -maxSingleForce;
		return vec.normalized * mag;
	}

	protected Vector3 sumForces()
	{
		Vector3 pos1 = transform.position;
		float charge1 = GetComponent<ChargeController> ().charge;
		Vector3 totalForce = Vector3.zero;
		for (int i = 0; i < charges.Length; i++)
		{
			GameObject go = charges[i];
			Vector3 pos2 = go.transform.position;
			float charge2 = go.GetComponent<ChargeController>().charge;
			totalForce = totalForce + CoulombsForce(pos1, pos2, charge1, charge2);
		}
		return totalForce;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 force = new Vector3 (moveHorizontal, 0.0F, moveVertical) * moveStrength;
		force += sumForces();

		rb.AddForce (force);

		if (Input.GetKeyDown ("space")) {
			rb.AddForce(new Vector3(0F, 300F, 0F));
			Debug.Log("space");
		}
	}

}
