using UnityEngine;

public class RBPlayerCam : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
