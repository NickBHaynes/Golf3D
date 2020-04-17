using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public LayerMask playerLayer;

    public LevelDetails theLev;
    private int levelNum;


    private void Start()
    {
        levelNum = theLev.levelNum;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("triggered");
            EventsManager.instance.SpawnLevelDetails(levelNum);
        }
    }
}
