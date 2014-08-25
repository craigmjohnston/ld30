using System;
using System.Linq;
using UnityEngine;
using System.Collections;

public class SwitchOffLights : MonoBehaviour {
    public enum Stage { Estate, Farm, House }
    public Stage stage;

    public Material litWindowMaterial;
    public Material unlitWindowMaterial;

	// Use this for initialization
	void Start () {
	    var globalVars = FindObjectOfType<GlobalVars>();
	    if (stage == Stage.Estate && globalVars.finishedEstate) {
	        SwitchOff();
	        return;
	    }
        if (stage == Stage.Farm && globalVars.finishedFarm) {
            SwitchOff();
            return;
        }
        if (stage == Stage.House && globalVars.finishedHouse) {
            SwitchOff();
            return;
        }
	}

    protected void SwitchOff() {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var lightshaft in renderers.Where(r => r.gameObject.name == "Lightshaft")) {
            lightshaft.enabled = false;
        }
        foreach (MeshRenderer r in renderers) {
            Material[] materials = r.materials;
            for (int i = 0; i < materials.Length; i++) {
                if (materials[i].name.Contains("Lit Window")) {
                    materials[i] = unlitWindowMaterial;
                }
            }
            r.materials = materials;
        }
        foreach (var l in GetComponentsInChildren<Light>()) {
            l.enabled = false;
        }
        foreach (var door in GetComponents<ToggleSlide>()) {
            door.gameObject.layer = 0;
        }
    }
}