using UnityEngine;
using System.Collections;

public class ChaseMe : MonoBehaviour {
    public Transform chaser;
    public float runDistance;
    public float runSpeed;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Pen") {
            iTween.MoveBy(gameObject, (new Vector3(other.bounds.center.x, transform.position.y, other.bounds.center.z) - transform.position).normalized * Random.Range(0.5f, 4), 3);
            transform.LookAt(new Vector3(other.bounds.center.x, transform.position.y, other.bounds.center.z));
            enabled = false;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Vector3.Distance(chaser.position, transform.position) < runDistance) {
            transform.LookAt(new Vector3(chaser.position.x, transform.position.y, chaser.position.z));
            transform.Rotate(0, 180, 0);
	        transform.position += transform.forward * runSpeed * Time.deltaTime;
	    }
	}
}