using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiceRoll : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb != null)
        {
            diceVelocity = rb.velocity;
        }
    }
}
