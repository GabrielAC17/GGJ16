using UnityEngine;
using System.Collections;

public class DefaultBlock : MonoBehaviour {
	public int blockType = 1;	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	private void updateStyle(){
		SpriteRenderer spt = this.GetComponent<SpriteRenderer> ();
		switch(blockType){
		case 1:
			spt.color = new Color (0f,0f,1f,1f); 
			break;
		case 2:
			spt.color = new Color (1f,0f,0f,1f); 
			break;
		case 3:
			spt.color = new Color (0f,0.75f,1f,1f); 
			break;
		case 4:
			spt.color = new Color (0f,1f,0f,1f); 
			break;
		}
	}
	public void setType(int type){
		this.blockType = type;
		updateStyle ();
	}
	public int getType(){
		return this.blockType;
	}
}
