using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;
    public Transform cameraPivot;
    public float smoothSpeed;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, cameraPivot.transform.position, smoothSpeed);
    }
}