using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform cameraAnchor;
    private Vector3 cameraOffset;

    InputAction lookAction;
    Vector3 cameraAngels;

    float snsH = 4f;
    float snsV = 3f;

    float maxAngle = 60f;
    float minAngle = -80f;

    void Start()
    {
        cameraOffset = this.transform.position - cameraAnchor.position;
        lookAction = InputSystem.actions.FindAction("Look");
    }
    void Update(){
        Vector2 lookValue = Time.deltaTime * lookAction.ReadValue<Vector2>();

        cameraAngels.x -= Math.Clamp(  lookValue.y * snsV, minAngle, maxAngle);
        cameraAngels.y += lookValue.x * snsH;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.eulerAngles = cameraAngels;
        this.transform.position = cameraAnchor.position + Quaternion.Euler(0, cameraAngels.y, 0)* cameraOffset;


    }
}
