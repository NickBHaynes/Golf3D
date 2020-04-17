using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer theLineRenderer;
    private Vector3 grapplePoint;
    private SpringJoint joint;

    public LayerMask whatIsGrappleable;
    public Transform gunTip, theCam, player;
    public float range = 100;

    [Header("Grapple Adjust")]
    public float maxGrappleDistanceLengthMultiplier = 0.8f;
    public float minGrappleDistanceLengthMultiplier = 0.25f;
    public float springForce = 4.5f;
    public float springDampener = 7f;
    public float springMassScale = 4.5f;

    private void Awake()
    {
        theLineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void StartGrapple()
    {
        if (Physics.Raycast(theCam.position, theCam.forward, out RaycastHit hit, range, whatIsGrappleable))
        {
            Debug.Log(hit.transform.name);
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            // the min and max distance the grapple will try to keep from the grapple point
            joint.maxDistance = distanceFromPoint * maxGrappleDistanceLengthMultiplier;
            joint.minDistance = distanceFromPoint * minGrappleDistanceLengthMultiplier;

            joint.spring = springForce;
            joint.damper = springDampener;
            joint.massScale = springMassScale;

            theLineRenderer.positionCount = 2;

        }
    }

    void StopGrapple()
    {
        theLineRenderer.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        if (!joint) return;

        theLineRenderer.SetPosition(0, gunTip.position);
        theLineRenderer.SetPosition(1, grapplePoint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplingPoint()
    {
        return grapplePoint;
    }
}
