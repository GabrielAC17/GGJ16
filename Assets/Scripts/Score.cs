using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public static int score = 0;
	// Use this for initialization
	void Start () {
		Score.score = 0;
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void plusScore (int score){
		Score.score+=score;
	}
}
