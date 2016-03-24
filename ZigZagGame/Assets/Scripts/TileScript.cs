using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {
	private int fallDelay=2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			Debug.Log ("Spawn TIle");
			TiileManager.Instance.SpawnTile();
			StartCoroutine (FallDown());
		}
	}
	IEnumerator FallDown(){
		yield return new WaitForSeconds(fallDelay);
		GetComponent<Rigidbody> ().isKinematic = false;	
		yield return new WaitForSeconds(fallDelay);
		TiileManager.Instance.stackTiles.Push (gameObject);
		GetComponent<Rigidbody> ().isKinematic = true;	
		gameObject.SetActive (false);
	}
}
