using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float speed=10;
	private Vector3 dir;


	// Use this for initialization
	void Start () {
		dir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (dir == Vector3.forward) {
				dir = Vector3.left;
			} else {
				dir = Vector3.forward;
			}
		}
		float amountMove = speed * Time.deltaTime;
		transform.Translate (dir * amountMove);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Pickup") {
			other.gameObject.SetActive(false);
		}
	}
		

}
