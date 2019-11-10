using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    private CameraControl _cameraController;
    private GameObject _camera;

    void Awake()
    {
        _cameraController = GameObject.FindObjectOfType<CameraControl>();
        _camera = _cameraController.ActualCamera;
    }

    void Update()
    {
        _camera = _cameraController.ActualCamera;
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}
