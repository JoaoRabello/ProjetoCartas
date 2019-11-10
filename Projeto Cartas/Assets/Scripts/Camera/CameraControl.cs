using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject _camera1;
    [SerializeField] private GameObject _camera2;

    private GameObject _actualCamera;

    private int actualCameraIndex = 0;

    public GameObject ActualCamera { get => _actualCamera; }

    public void CameraChange(int camera)
    {
        actualCameraIndex = camera;
        switch (actualCameraIndex)
        {
            case 0:
                _actualCamera = _camera1.gameObject;
                _camera1.SetActive(true);
                _camera2.SetActive(false);
                break;
            case 1:
                _actualCamera = _camera2.gameObject;
                _camera1.SetActive(false);
                _camera2.SetActive(true);
                break;
        }
    }
}
