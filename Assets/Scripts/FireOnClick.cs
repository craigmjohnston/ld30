using UnityEngine;
using System.Collections;

public class FireOnClick : MonoBehaviour {
    public LayerMask enemyMask;
    public Transform bulletPrefab;
    public float timeLimit;

    protected float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    timer += Time.deltaTime;
	    if (timer >= timeLimit) {
	        // badguy shoots, player dies
            var bullet = (Transform)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.rotation = transform.rotation;
            audio.Play();
            FindObjectOfType<TransitionToScene>().Transition();
            enabled = false;
            FindObjectOfType<GlobalVars>().isDead = true;
	    }
	    if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)) {
            audio.Play();
            var bullet = (Transform)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.rotation = transform.rotation;
	        RaycastHit hitInfo;
	        if (Physics.Raycast(Camera.main.ViewportPointToRay(Vector2.one*0.5f), out hitInfo, 10000, enemyMask)) {
	            // hit - player lives
                FindObjectOfType<GlobalVars>().isDead = false;
	        } else {
                // missed - player dies
                FindObjectOfType<GlobalVars>().isDead = true;
	        }
            enabled = false;
            FindObjectOfType<TransitionToScene>().Transition();
	    }
	}
}