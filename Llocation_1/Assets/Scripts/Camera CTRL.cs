using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCTRL : MonoBehaviour
{
    [Header("Mouse Parametrs")]
    [SerializeField, Range(100, 1000)] private float xSens = 600f;
    [SerializeField, Range(100, 1000)] private float ySens = 600f;
    [SerializeField, Range(-90, 0)] private float uppLookLimit = -90f;
    [SerializeField, Range(90, 0)] private float lowLookLimit = 90f;

    public Transform player;
    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;

        xRotation -= mY;
        xRotation = Mathf.Clamp(xRotation, uppLookLimit, lowLookLimit);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mX);
    }
}
