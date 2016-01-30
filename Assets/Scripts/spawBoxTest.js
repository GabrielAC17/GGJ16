#pragma strict
var prefab =  new UnityEngine.Object();
var block1 = new UnityEngine.Object();
var block2 = new UnityEngine.Object();
var block3 = new UnityEngine.Object(); 
var block4 = new UnityEngine.Object();
function Start () {
	Example();
}

var delay = 1;

function Update () {
		
}

function SpawnObject() {
	 Instantiate(prefab, this.transform.position, Quaternion.identity);
}

function Example() {
	InvokeRepeating("SpawnObject", 2, delay);
}