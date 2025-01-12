using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // The sprite (player) the camera should follow
    public Vector3 offset;         // Offset between the camera and the sprite
    public float smoothSpeed = 0.125f;  // Smooth factor for camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position with the offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Apply the smoothed position to the camera
            transform.position = smoothedPosition;
        }
    }
}
