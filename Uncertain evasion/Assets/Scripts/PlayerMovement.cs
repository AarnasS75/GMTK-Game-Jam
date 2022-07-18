using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform LookAtMouse;
    [SerializeField] float Speed = 8f;

    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundDistance = 0.2f;
    [SerializeField] LayerMask GroundMask;

    bool isGrounded;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;

        Vector3 move = LookAtMouse.right * horizontal + LookAtMouse.forward * vertical;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }
}
