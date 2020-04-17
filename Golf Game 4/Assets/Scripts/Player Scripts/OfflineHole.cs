using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineHole : MonoBehaviour
{
    public GameObject successVFX;

    [SerializeField]
    private int scoreValue = 1;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Ball"))
        {
            EventsManager.instance.PlayerScore(scoreValue);

            if (successVFX != null)
            {
                Instantiate(successVFX, transform.position, Quaternion.identity);
            }
        }
    }
}
