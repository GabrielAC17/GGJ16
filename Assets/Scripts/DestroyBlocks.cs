﻿using UnityEngine;
using System.Collections;

public class DestroyBlocks : MonoBehaviour {
	private bool isCombo = false;
	private bool allBlocksVerified = true;
	private ArrayList listToRemove= new ArrayList();
	private ArrayList allList= new ArrayList();
    private bool isDestroyed = false;
    private bool[] DisableSpecial;

	public void destroyBlocks(int blockType){
		//Debug.Log ("typeBlock to destroy: " + blockType);
		foreach (Collider2D obj in allList) {
			DefaultBlock objToTest = obj.GetComponent<DefaultBlock> ();
			if(objToTest.blockType == blockType)
            {
                Destroy(obj.gameObject);
                isDestroyed = true;
                GameObject.FindGameObjectWithTag("GameManager").SendMessage("removeBlocks");
            }

		    if (objToTest.blockType == 1 && !DisableSpecial[0])
            {
                GameObject.FindGameObjectWithTag("GameManager").SendMessage("Specials", 1);
                DisableSpecial[0] = true;
            }
            if (objToTest.blockType == 2 && !DisableSpecial[1])
            {
                GameObject.FindGameObjectWithTag("GameManager").SendMessage("Specials", 2);
                DisableSpecial[1] = true;
            }
            if (objToTest.blockType == 3 && !DisableSpecial[2])
            {
                GameObject.FindGameObjectWithTag("GameManager").SendMessage("Specials", 3);
                DisableSpecial[2] = true;
            }
            if (objToTest.blockType == 4 && !DisableSpecial[3])
            {
                GameObject.FindGameObjectWithTag("GameManager").SendMessage("Specials", 4);
                DisableSpecial[3] = true;
            }
        }
        if (isDestroyed)
        {
            allList.Clear();
            isDestroyed = false;
        }
	}

	void OnTriggerStay2D(Collider2D other) {
		//Debug.Log ("TriggerStay");
		if (!allList.Contains (other)) {
			allList.Add (other);
			Debug.Log ("Block "+ other.gameObject.GetInstanceID() + " added!!");
		}

	}

    void ResetSpecialAir()
    {
        DisableSpecial[3] = false;
    }
			
	// Use this for initialization
	/*
	 * 1- Agua
	 * 2- Fogo
	 * 3- Terra
	 * 4- Ar
 	*/
	void Start () {
        DisableSpecial = new bool[4];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
