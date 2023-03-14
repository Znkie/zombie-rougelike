using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate (){
        transform.position = target.position + offset;
        // Additional code to rotate camera with player, but seems to have a bug where camera is shown too low on the y-axis.
        // transform.LookAt(target, Vector3.up);
    }
}
