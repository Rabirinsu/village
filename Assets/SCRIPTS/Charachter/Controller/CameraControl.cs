using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float lerpValue;
    void Start()
    {

    }


    void LateUpdate()
    {
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            var desPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
        }
    }
}
