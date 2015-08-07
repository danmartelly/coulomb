using UnityEngine;
using System.Collections;

public class ChargeController : MonoBehaviour {

	public float charge;
	public Color negColor;
	public Color posColor;
	public Color neutralColor;

	void Start()
	{
		Renderer rend = GetComponent<Renderer> ();
		if (this.charge < 0) {
			rend.material.color = negColor;
		} else if (this.charge > 0) {
			rend.material.color = posColor;
		} else {
			rend.material.color = neutralColor;
		}
	}

}
