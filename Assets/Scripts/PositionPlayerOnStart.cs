using UnityEngine;
using System.Collections;

public class PositionPlayerOnStart : MonoBehaviour {
    public Transform player;

	void Start () {
	    var globalVars = FindObjectOfType<GlobalVars>();
	    // TODO put the player in the carriage they left
	    if (globalVars.finishedEstate && globalVars.finishedFarm && globalVars.finishedHouse) {
	        // move player to outside driver's door
            player.position = new Vector3(0, 4.6f, 23f);
            player.rotation = Quaternion.identity;
	        return;
	    }
	    switch (globalVars.lastLevel) {
	        case 2: // estate
                player.position = new Vector3(-0.8027695f, 3.877787f, -5.238976f);
	            player.rotation = Quaternion.Euler(0, 163.6265f, 0);
	            break;
            case 3: // farm
                player.position = new Vector3(1.715254f, 3.877787f, -47.27536f);
                player.rotation = Quaternion.Euler(0, 195.96f, 0);
	            break;
            case 4: // house
                player.position = new Vector3(-1.022195f, 4.236435f, -85.11746f);
                player.rotation = Quaternion.Euler(0, 373.88f, 0);
	            break;
	    }
	}
}