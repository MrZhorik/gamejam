using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanicCollider : MonoBehaviour
{
    public GameObject car;

    private PrometeoCarController carController;
    private Rigidbody carRigidbody;
    private Vector3 colliderScale = Vector3.one;
    private Vector3 lastPosition; 

    private void Start()
    {
        lastPosition = transform.position;
        carController = car.GetComponent<PrometeoCarController>();
        carRigidbody = car.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PanicColliderRotate();
        PanicColliderStretch();
        PanicColliderMove();
    }

    private void PanicColliderRotate()
    {
        if (carRigidbody.velocity.magnitude < 0.1f)
            return;

        if (carController.carSpeed > 0)
        {
            transform.forward = carRigidbody.velocity.normalized;
        }
        else if (carController.carSpeed < 0)
        {
            transform.forward = -carRigidbody.velocity.normalized;
            transform.Rotate(0, 180f, 0);
        }
    }

    private void PanicColliderStretch()
    {
        colliderScale.z = Math.Abs(carController.carSpeed/30);
        transform.localScale = colliderScale;
    }

    private void PanicColliderMove()
    {
        //if (carController.carSpeed > 0)
        //{
        //    transform.localPosition = new Vector3(carRigidbody.velocity.normalized.x * carController.carSpeed/30, 0, carRigidbody.velocity.normalized.z * carController.carSpeed/30);
        //}
    }
}
