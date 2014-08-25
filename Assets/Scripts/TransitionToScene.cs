using UnityEngine;

public class TransitionToScene : MonoBehaviour {
    public dfPanel fadePanel;
    public int sceneId;

    public delegate void TransitionEventHandler();
    public event TransitionEventHandler Transitioning = delegate {};

    protected bool isTransitioning = false;
    protected int newSceneId;
	
	void Update () {
	    if (isTransitioning && fadePanel.BackgroundColor.a == 255) {
	        Application.LoadLevel(newSceneId);
	    }
	}

    public void Transition(int newSceneId = -1) {
        Transitioning();
        if (FindObjectOfType<CharacterController>() != null) {
            FindObjectOfType<CharacterController>().enabled = false;
            FindObjectOfType<SmoothMouseLook>().enabled = false;
        }
        this.newSceneId = newSceneId == -1 ? sceneId : newSceneId;
        isTransitioning = true;
        switch (Application.loadedLevelName) {
            case "Council Estate":
                FindObjectOfType<GlobalVars>().finishedEstate = true;
                break;
            case "Farm":
                FindObjectOfType<GlobalVars>().finishedFarm = true;
                break;
            case "House":
                FindObjectOfType<GlobalVars>().finishedHouse = true;
                break;
            case "Skyscraper":
                FindObjectOfType<GlobalVars>().finishedSkyscraper = true;
                break;
        }
    }
}