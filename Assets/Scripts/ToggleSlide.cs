using UnityEngine;

public class ToggleSlide : MonoBehaviour {
    public Vector3 slideAmount;
    public float time;
    public float toggleClosedTime;

    protected enum State { Closed, Open, Closing, Opening }
    protected State state = State.Closed;
    protected Vector3 initialPosition;
    protected float closeTimer = 0;

	void Start () {
	    initialPosition = transform.position;
	}

    void Update() {
        if (state == State.Opening && transform.position == initialPosition + slideAmount) {
            state = State.Open;
            if (toggleClosedTime != 0) {
                closeTimer = toggleClosedTime;
            }
        } else if (state == State.Closing && transform.position == initialPosition) {
            state = State.Closed;
        }
        if (closeTimer > 0 && state == State.Open) {
            closeTimer -= Time.deltaTime;
            if (closeTimer <= 0) {
                Toggle();
            }
        }
    }

    public void Toggle() {
        iTween.Stop(gameObject);
        closeTimer = 0;
        if (state == State.Closed || state == State.Closing) {
            iTween.MoveTo(gameObject, initialPosition + slideAmount, time);
            state = State.Opening;
        } else {
            iTween.MoveTo(gameObject, initialPosition, time);
            state = State.Closing;
        }
    }
}