using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    //Reference to code/ video for player movement with camera "https://www.youtube.com/watch?v=MFQhpwc6cKE"

    //Camera to follow the player when moving

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
