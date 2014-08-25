using UnityEngine;
using System.Collections;

public class CollectOnKey : MonoBehaviour {
    public KeyCode key;
    public float maxDistance;
    public LayerMask collectableMask;

	void Update () {
        if (Input.GetKeyDown(key)) {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ViewportPointToRay(Vector2.one * 0.5f), out hitInfo, maxDistance, collectableMask)) {
                Destroy(hitInfo.collider.gameObject);
            }
        }
	}
}
