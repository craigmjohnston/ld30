using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {
    public bool finishedEstate = false;
    public bool finishedFarm = false;
    public bool finishedHouse = false;
    public bool finishedSkyscraper = false;
    public bool isDead = false;

    public int lastLevel;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Screen.lockCursor) {
            Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
            if (screenRect.Contains(Input.mousePosition)) {
                Screen.lockCursor = true;
            }
        }
    }
}