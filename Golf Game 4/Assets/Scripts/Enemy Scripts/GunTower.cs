using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : MonoBehaviour, IEntity
{
    OfflinePlayer thePlayer;
    bool playerFound;

    public float rotaionSpeed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerFound)
        {
            StartGame();
        }

        if (playerFound)
        {
            RotateTower();
        }
    }

    #region IEntity Mandatories

    public void StartGame()
    {
        thePlayer = FindObjectOfType<OfflinePlayer>();
        if (thePlayer != null)
        {
            playerFound = true;
        }
    }

    public void EndGame()
    {

    }

    public void SubscribeEvents()
    {

    }

    public void UnSubscribeEvents()
    {

    }
    #endregion

    private void RotateTower()
    {
        Vector3 dir = (thePlayer.transform.position - transform.position);
        //float angle = Mathf.Atan(dir.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void StandUp()
    {

    }
}
