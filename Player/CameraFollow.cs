using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform thePlayer;
    public float speed;

    private bool smooth = true;
    private Vector3 offset = new Vector3(0, 30, -6.5f);

    void LateUpdate() {
        Vector3 desiredPosition = thePlayer.transform.position + offset;

        if(smooth) {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, speed);
        } else {
            transform.position = desiredPosition;
        }

        // Exactly clamps the camera to the 25x25 play zone
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -355, 355), Mathf.Clamp(transform.position.y, -550, 550), -6.5f);
    }
}
