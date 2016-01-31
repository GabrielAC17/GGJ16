using UnityEngine;
using System.Collections;

public class SeedTotens : MonoBehaviour {
	public GameObject[] prefabBlocks; 
	public float distanceX = 5;
	public float positionY = 10;
	public float z=11;
	private int[][] totens ={new int[]{1,4,2,3,1,1,4,1,4,2},new int[]{2,2,2,4,1,4,2,3,1,1},new int[]{4,2,1,2,3,4,2,1,4,4},new int[]{3,4,4,1,2,1,3,2,1,2}};
	// Use this for initialization
	void Start () {
		float[] positionsX = {-distanceX-distanceX/2,-distanceX/2,distanceX/2,distanceX+distanceX/2};
		for(var totensIndx=0;totensIndx<totens.Length; totensIndx++){
			var totensSequence = totens[totensIndx];
			for(var blockIndx=0;blockIndx<totensSequence.Length; blockIndx++){
				var blockType = totens[totensIndx][blockIndx];
				var gameObject = Instantiate(prefabBlocks[blockType-1],new Vector3(positionsX[totensIndx], positionY+(blockIndx*4), 0), Quaternion.identity) as GameObject;
				DefaultBlock obj = gameObject.GetComponent<DefaultBlock> ();
				obj.setType(blockType);
				obj.transform.position = new Vector3 (obj.transform.position.x, obj.transform.position.y, (z + (-0.1f * blockIndx)));
                GameObject.FindGameObjectWithTag("GameManager").SendMessage("addBlocks");
            }
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}