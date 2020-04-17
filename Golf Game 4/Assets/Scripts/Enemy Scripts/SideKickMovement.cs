using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideKickMovement : MonoBehaviour
{
    OfflinePlayer thePlayer;
    Rigidbody theRb;
    public float distanceToPlayer = 30f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<OfflinePlayer>();
        theRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        FacePlayer();
    }

    void FindGround()
    {

    }

    void FollowPlayer()
    {
        Vector3 dir = (transform.position - thePlayer.transform.position);

        if (dir.magnitude > distanceToPlayer)
        {
            Vector3 targetPos = new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    void FacePlayer()
    {
        Vector3 dir = (thePlayer.transform.position - transform.position);

        transform.rotation = Quaternion.LookRotation(dir);
    }
}
