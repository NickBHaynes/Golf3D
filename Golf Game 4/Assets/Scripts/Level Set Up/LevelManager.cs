using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour, ILevelManager
{
   // public static LevelManager instance;

    private int currentScore;
    private int levNumber;

    [Header("Level Layout")]
    public NavMeshSurface surface;
    public int chunkAmounts = 3;
    public GameObject[] levels;
    public List<GameObject> ingameLevels = new List<GameObject>();
    public Transform levelParent;

    [Header("Level Data")]
    public float levelTime = 60;

    [Header ("Player")]
    public GameObject player;
    private GameObject thePlayer;
    public Transform playerStartPoint;

    [Header("Level Menu Assets")]
    public GameObject menuCamera;
    public GameObject menuCanvas;
    public GameObject gameCanvas;
    public GameObject gameOverCanvas;

    private void Awake()
    {
      //  instance = this; 
    }

    public void Start()
    {
        EventsManager.instance.OnPlayerScore += GoalScored;
    }

    void SetUpMap()
    {
        for (int i = 0; i < chunkAmounts; i++)
        {

            GameObject lev = Instantiate(levels[Random.Range(0, levels.Length)], new Vector3(-0, 0, ((i + 1) * 90)), Quaternion.identity, levelParent);
            lev.GetComponent<LevelDetails>().levelNum = i + 1;
            ingameLevels.Add(lev);
        }
        surface.BuildNavMesh();
    }

    public void StartGame()
    {
        SetUpMap();
        menuCamera.SetActive(false);
        menuCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        gameCanvas.SetActive(true);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        EventsManager.instance.StartGame(levelTime, 0);

        SubscribeEvents();
        

        GameObject newPlayer = Instantiate(player, playerStartPoint.position, Quaternion.identity);
        
    }

    public void EndGame()
    {
        UnSubscribeEvents();

        DestroyLevels();
        levNumber = 0;

        menuCamera.SetActive(true);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

       // ingameLevels.Clear();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void SubscribeEvents()
    {
        EventsManager.instance.OnEndGame += EndGame;
        EventsManager.instance.OnPlayerScore += UpdateScore;
    }

    public void UnSubscribeEvents()
    {
        EventsManager.instance.OnEndGame -= EndGame;
        EventsManager.instance.OnPlayerScore -= UpdateScore;
    }

    private void DestroyLevels()
    {
        foreach (var level in ingameLevels)
        {
            level.GetComponent<LevelDetails>().EndGame();
            Destroy(level.gameObject);
        }

        ingameLevels.Clear();
    }

    private void GoalScored(int _score)
    {
        ingameLevels[levNumber].GetComponent<LevelDetails>().entryBridge.SetActive(false);
        ingameLevels[levNumber].GetComponent<LevelDetails>().exitBridge.SetActive(true);
        levNumber++;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    private void UpdateScore(int _score)
    {
        currentScore += _score;
    }
}
