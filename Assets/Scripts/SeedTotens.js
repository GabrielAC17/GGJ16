#pragma strict
var prefabBlocks = [new UnityEngine.Object(),new UnityEngine.Object(),new UnityEngine.Object(),new UnityEngine.Object()];
var distanceX = 5.0;


var positionY = 3;

function Start () {
	var positionsX = [-distanceX-distanceX/2,-distanceX/2,distanceX/2,distanceX+distanceX/2];
	var totens = [[1,2,4,2,3,4,2,3,1,4,3,2],[1,2,3,3,2,4,1,2,3],[1,2,3,4,1,2,2,3,4],[1,2,3,3,2,2,4,4,1,1]];


	for(var totensIndx=0;totensIndx<totens.Length; totensIndx++){
		var totensSequence = totens[totensIndx];
		for(var blockIndx=0;blockIndx<totensSequence.Length; blockIndx++){
			var blockType = totens[totensIndx][blockIndx];
				Instantiate(prefabBlocks[blockType-1],new Vector3(positionsX[totensIndx],positionY+(blockIndx*3.5), 0), Quaternion.identity);
			}
		}
	}


function Update () {
	
}