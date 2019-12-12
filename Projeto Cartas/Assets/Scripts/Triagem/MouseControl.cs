using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private Camera cam;
    [SerializeField] Transform firstCamPos;
    [SerializeField] Transform tableCamPos;
    [SerializeField] Transform bagCamPos;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                CheckClickedObject(hit.collider.tag);
            }
        }
    }

    private void CheckClickedObject(string tag)
    {
        switch (tag)
        {
            case "Table":
                StopAllCoroutines();
                StartCoroutine(MoveToPosition(transform, tableCamPos, 2f));
                break;
            case "Bag":
                StopAllCoroutines();
                StartCoroutine(MoveToPosition(transform, bagCamPos, 2f));
                break;
            default:
                StopAllCoroutines();
                StartCoroutine(MoveToPosition(transform, firstCamPos, 1.5f));
                break;
        }
    }

    IEnumerator MoveToPosition(Transform initialPoint, Transform targetPoint, float timeOffset)
    {
        float startTime = Time.time;
        while (Time.time < startTime + timeOffset)
        {
            transform.position = Vector3.Lerp(initialPoint.position, targetPoint.position, (Time.time - startTime) / timeOffset);
            transform.rotation = Quaternion.Lerp(initialPoint.rotation, targetPoint.rotation, (Time.time - startTime) / timeOffset);
            yield return null;
        }
        cam.transform.position = targetPoint.position;
    }
}
