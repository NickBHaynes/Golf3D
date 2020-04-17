using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLevelManager : MonoBehaviour, ILevelManager
{

    public GameObject menuCam;
    public GameObject gameCanvas;

    private void Start()
    {
        // temp start game
        StartGame();
    }

    public void StartGame()
    {
        menuCam.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void EndGame()
    {
        menuCam.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void SubscribeEvents()
    {

    }

    public void UnSubscribeEvents()
    {

    }

}
