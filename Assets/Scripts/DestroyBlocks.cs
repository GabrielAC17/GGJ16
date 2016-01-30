using UnityEngine;
using System.Collections;

public class DestroyBlocks : MonoBehaviour {
	private bool isCombo = false;
	private bool allBlocksVerified = true;
	private ArrayList listToRemove= new ArrayList();
	private ArrayList allList= new ArrayList();
	public void destroyBlocks(int blockType){
		Debug.Log ("typeBlock to destroy: " + blockType);
		foreach (Collider2D obj in allList) {
			Destroy (obj.gameObject);
		}
		allList= new ArrayList();
	}

	void OnTriggerStay2D(Collider2D other) {
		Debug.Log ("TriggerStay");
		if (!allList.Contains (other)) {
			allList.Add (other);
			Debug.Log ("Block "+ other.gameObject.GetInstanceID() + " added!!");
		}

	}
			
	// Use this for initialization
	/*
	 * 1- Agua
	 * 2- Fogo
	 * 3- Terra
	 * 4- Ar
 	*/
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
