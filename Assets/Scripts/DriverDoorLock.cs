using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DriverDoorLock : MonoBehaviour {
    public MeshRenderer firstKey;
    public MeshRenderer secondKey;
    public MeshRenderer thirdKey;

    public GameObject door;
    public int doorLayer;

    public Material lockMaterial;

    protected GlobalVars globalVars;

	void Start () {
        lockMaterial.color = new Color(lockMaterial.color.r, lockMaterial.color.g, lockMaterial.color.b, 1);
	    globalVars = FindObjectOfType<GlobalVars>();
        firstKey.enabled = globalVars.finishedEstate;
        secondKey.enabled = globalVars.finishedFarm;
        thirdKey.enabled = globalVars.finishedHouse;
        if (globalVars.finishedEstate && globalVars.finishedFarm && globalVars.finishedHouse) {
            StartCoroutine(FadeLock(3));
            door.layer = doorLayer;
        }
	}

    protected IEnumerator<WaitForEndOfFrame> FadeLock(float time) {
        Color startColour = lockMaterial.color;
        Color endColour = new Color(startColour.r, startColour.g, startColour.b, 0);
        float progress = 0;
        while (progress < time) {
            progress += Time.deltaTime;
            lockMaterial.color = Color.Lerp(startColour, endColour, progress/time);
            yield return new WaitForEndOfFrame();
        }
        firstKey.enabled = false;
        secondKey.enabled = false;
        thirdKey.enabled = false;
    }
}
