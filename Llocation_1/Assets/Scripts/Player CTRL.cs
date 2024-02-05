using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    [Header("Movement parametrs")] 
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float gravity = -9.8f;

    [Header("Jump parametrs")]
    [SerializeField, Range(1, 10)] private float jumpHeight = 3.0f;
    [SerializeField, Range(0.1f, 1.0f)] private float graundDisp = 0.4f;

    public CharacterController controller;
    public Transform graundCheck;
    public Vector3 velocity;
    public LayerMask graundMask;
    private bool isGraund;

    void Update()
    {
        isGraund = Physics.CheckSphere(graundCheck.position, graundDisp, graundMask);

        if( isGraund && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGraund)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
