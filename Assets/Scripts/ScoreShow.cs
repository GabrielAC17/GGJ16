using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour {
	public Text score;
	// Use this for initialization
	void Start () {
		score.text ="Score "+ Score.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
