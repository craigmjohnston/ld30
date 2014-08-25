using UnityEngine;
using System.Collections;

public class FocusThenTransition : MonoBehaviour {
    public Transform player;
    public Transform focusOn;
    public float focusDuration;

    protected bool focusing = false;
    protected float focusingTimer = 0;

    public void Focus() {
        iTween.LookTo(player.gameObject, focusOn.position, 4);
        FindObjectOfType<CharacterController>().enabled = false;
        FindObjectOfType<SmoothMouseLook>().enabled = false;
        focusing = true;
    }

    void Update() {
        if (focusing) {
            focusingTimer += Time.deltaTime;
            if (focusingTimer >= focusDuration + 4) {
                FindObjectOfType<TransitionToScene>().Transition();
                enabled = false;
            }
        }
    }
}