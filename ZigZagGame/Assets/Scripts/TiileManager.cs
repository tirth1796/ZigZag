using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TiileManager : MonoBehaviour {
	public GameObject tilePrefab;
	public GameObject currentTile;
	public Stack<GameObject> stackTiles = new Stack<GameObject> ();
	private static TiileManager instance;
	public static TiileManager Instance{
		get{
			if(instance==null){
				instance=GameObject.FindObjectOfType<TiileManager>();
			}


			return TiileManager.instance;
		}
	}
	// Use this for initialization
	void Start () {
		for (int i =0; i<40; i++) {
			SpawnTile ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateTiles(int amount){
		for (int i =0; i<amount; i++) {
			stackTiles.Push(Instantiate(tilePrefab));
			stackTiles.Peek().SetActive(false);
		}
	}

	public void SpawnTile(){

		if (stackTiles.Count == 0) {
			CreateTiles(30);
		}
		int randIndex = Random.Range (1,3);
		GameObject tmp = stackTiles.Pop ();
		tmp.SetActive(true);
		tmp.transform.position = currentTile.transform.GetChild(randIndex).position;
		currentTile = tmp;
//		currentTile=(GameObject) Instantiate(tilePrefab,currentTile.transform.GetChild(randIndex).position,Quaternion.identity);

		randIndex = Random.Range (0, 4);
		if (randIndex == 3) {
			currentTile.transform.GetChild(4).gameObject.SetActive(true);
		}




	}
}
