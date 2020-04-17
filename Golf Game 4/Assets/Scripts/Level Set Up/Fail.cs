using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    public LevelDetails theLev;
    public int levelNum;

    private void Start()
    {
        levelNum = theLev.levelNum;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Ball"))
        {
            EventsManager.instance.ResetBall();
        }
        if (otherCollider.CompareTag("Player"))
        {
            EventsManager.instance.ResetPlayer();
        }
    }
}
