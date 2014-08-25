using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {
    public float shakeAmount;
    public float smoothTime;

    protected Vector3 startPosition;
    protected Vector3 velocity;

    void Start() {
        startPosition = transform.localPosition;
    }

	void Update () {
        transform.localPosition += new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f) * shakeAmount * Time.deltaTime;
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, startPosition, ref velocity, smoothTime);
	}
}