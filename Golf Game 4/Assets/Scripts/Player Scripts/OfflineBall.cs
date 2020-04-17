using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineBall : MonoBehaviour
{
    public string holeLayerName = "Hole";

    public LayerMask holeLayerMask;

    [SerializeField]
    private GameObject theBall;

    [SerializeField]
    private float damage = 1;

    private void Start()
    {
        EventsManager.instance.OnResetBallPos += ResetPos;
        EventsManager.instance.OnEndGame += EndGame;
        EventsManager.instance.OnPlayerScore += Score;
    }

    private void Score(int _score)
    {
        if (transform.parent != null)
        {
           GetComponentInParent<PickUpBall>().Drop();
        }
        EndGame();
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.layer != holeLayerMask)
        {
            if (transform.parent != null)
            {
                GetComponentInParent<PickUpBall>().Drop();
                //EventsManager.instance.OnDropBall();
            }
        }
    }

    private void ResetPos(Transform _newPos)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.position = _newPos.position;
    }

    public void EndGame()
    {
        EventsManager.instance.OnResetBallPos -= ResetPos;
        EventsManager.instance.OnEndGame -= EndGame;
        EventsManager.instance.OnPlayerScore -= Score;

        Destroy(theBall);
    }
}
