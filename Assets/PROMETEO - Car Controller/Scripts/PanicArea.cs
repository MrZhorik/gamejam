using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanicCollider : MonoBehaviour
{
    public float scaleCoeff = 10.0f;
    public GameObject car;

    private PrometeoCarController carController;
    private Rigidbody carRigidbody;
    private BoxCollider panicCollider;

    private Vector3 colliderScale = Vector3.one;
    private Vector3 lastPosition;
    private Vector3 initialScale;

    private void Start()
    {
        lastPosition = transform.position;
        carController = car.GetComponent<PrometeoCarController>();
        carRigidbody = car.GetComponent<Rigidbody>();
        panicCollider = GetComponent<BoxCollider>();
        initialScale = panicCollider.size;
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
        else
        {
            // FIXME
            transform.forward = carRigidbody.velocity.normalized;
        }
    }

    private void PanicColliderStretch()
    {
        if (colliderScale.z >= 1){
            transform.localScale = new Vector3(Math.Abs(carController.carSpeed / (20  * scaleCoeff)), transform.localScale.y, Math.Abs(carController.carSpeed / (20  * scaleCoeff)));
        }
    }

    private void PanicColliderMove()
    {
        if (carController.carSpeed > 0)
        {
            transform.localPosition = new Vector3(
                (panicCollider.size.x * transform.localScale.x) - initialScale.x, 
                0.8f, 
                (panicCollider.size.z * transform.localScale.z) - initialScale.z);
        }
    }
}
