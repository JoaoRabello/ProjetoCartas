using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private CameraControl _cameraControl;
    private GameObject _camera;
    [SerializeField] private float _speed;

    void Start()
    {
        _cameraControl = FindObjectOfType<CameraControl>();
        _camera = _cameraControl.ActualCamera;

        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _camera = _cameraControl.ActualCamera;

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 camF = _camera.transform.forward;
        Vector3 camR = _camera.transform.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        //Vector3 movement = new Vector3(input.x * camR.x, _rigidbody.velocity.y, input.y * camF.x) * Time.deltaTime * _speed;
        Vector3 horizontalMovement = input.x * camR * Time.deltaTime * _speed;
        Vector3 verticalMovement = input.y * camF * Time.deltaTime * _speed;

        //_rigidbody.MovePosition(transform.position + movement);
        _rigidbody.MovePosition(transform.position + horizontalMovement + verticalMovement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraArea"))
        {
            _cameraControl.CameraChange(other.GetComponent<CameraArea>().cameraNumber);
        }
    }
}
