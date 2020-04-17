using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGrapplingGun : MonoBehaviour
{
    public GrapplingGun grappling;

    private Quaternion desiredRotation;
    public float rotationSpeed = 5f;

    private void Update()
    {
        if (!grappling.IsGrappling())
        {
            desiredRotation = transform.parent.rotation;
        } else
        {
           desiredRotation = Quaternion.LookRotation(grappling.GetGrapplingPoint() - transform.position);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
