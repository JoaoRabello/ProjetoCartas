using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private CameraControl _cameraControl;
    private GameObject _camera;

    [SerializeField] private float _speed;
    private float _actualSpeed;
    private float _bikeSpeed;
    private bool _nextToBike = false;
    private bool _onBike = false;
    private GameObject _bike;

    void Start()
    {
        _cameraControl = FindObjectOfType<CameraControl>();
        _camera = _cameraControl.ActualCamera;

        _rigidbody = GetComponent<Rigidbody>();

        _actualSpeed = _speed;
        _bikeSpeed = _speed * 2f;
    }

    void Update()
    {
        _camera = _cameraControl.ActualCamera;

        BikeControl();
    }

    private void FixedUpdate()
    {
        NormalControl();
    }

    private void NormalControl()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 camF = _camera.transform.forward;
        Vector3 camR = _camera.transform.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        Vector3 horizontalMovement = input.x * camR * Time.deltaTime * _actualSpeed;
        Vector3 verticalMovement = input.y * camF * Time.deltaTime * _actualSpeed;

        _rigidbody.MovePosition(transform.position + horizontalMovement + verticalMovement);
    }

    private void BikeControl()
    {
        if (_nextToBike && !_onBike && Input.GetKeyDown(KeyCode.E))
        {
            _onBike = true;
            _actualSpeed = _bikeSpeed;
            _bike.transform.parent = transform;

        }
        else
        {
            if (_onBike && Input.GetKeyDown(KeyCode.E))
            {
                _onBike = false;
                _actualSpeed = _speed;
                _bike.transform.parent = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraArea"))
        {
            _cameraControl.CameraChange(other.GetComponent<CameraArea>().cameraNumber);
        }
        else
        {
            if (other.CompareTag("BikeArea"))
            {
                _nextToBike = true;
                _bike = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BikeArea"))
        {
            _nextToBike = false;
        }
    }
}
