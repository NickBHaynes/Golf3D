using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBallPickUp : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.transform.position = FindObjectOfType<RBPlayerController>().pickUpPoint.position;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
