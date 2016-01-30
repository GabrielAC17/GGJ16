using UnityEngine;
using System.Collections;

public class SeedTotens : MonoBehaviour {
	public GameObject[] prefabBlocks; 
	public float distanceX = 5;
	public float positionY = 10;
	private int[][] totens ={new int[]{1,2,4,2,3,4,2,3,1,4,3,2},new int[]{2,3,4,1,2,3,4},new int[]{3,4,1,2,3,4,3,2,2},new int[]{4,1,2,3,4,1,2,3,4}};
	// Use this for initialization
	void Start () {
		float[] positionsX = {-distanceX-distanceX/2,-distanceX/2,distanceX/2,distanceX+distanceX/2};
		for(var totensIndx=0;totensIndx<totens.Length; totensIndx++){
			var totensSequence = totens[totensIndx];
			for(var blockIndx=0;blockIndx<totensSequence.Length; blockIndx++){
				var blockType = totens[totensIndx][blockIndx];
				var gameObject = Instantiate(prefabBlocks[blockType-1],new Vector3(positionsX[totensIndx], positionY+(blockIndx*(5+blockIndx*(float)0.2)), 0), Quaternion.identity) as GameObject;
				DefaultBlock obj = gameObject.GetComponent<DefaultBlock> ();
				obj.setType(blockType);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}