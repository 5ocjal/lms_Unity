using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform cameraTarget;
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != cameraTarget.position)
        {
            Vector3 targetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }

    }
}
