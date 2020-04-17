using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflinePlayer : MonoBehaviour, IEntity
{
    [SerializeField]
    private float maxLives = 3;

    public float lives;

    private Transform lastPos;

    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        SubscribeEvents();

        EventsManager.instance.SetMiniMap(transform);
    }

    public void SubscribeEvents()
    {
        EventsManager.instance.OnPlayerScore += GoalScored;
        EventsManager.instance.OnResetPlayerPos += ResetPlayer;
        EventsManager.instance.OnHitEnemy_Player += HitEnemy;
        EventsManager.instance.OnEndGame += EndGame;
    }

    public void UnSubscribeEvents()
    {
        EventsManager.instance.OnPlayerScore -= GoalScored;
        EventsManager.instance.OnResetPlayerPos -= ResetPlayer;
        EventsManager.instance.OnHitEnemy_Player -= HitEnemy;
        EventsManager.instance.OnEndGame -= EndGame;
    }

    private void GoalScored(int _score)
    {
        Debug.Log("Goal Scored");
    }
    private void ResetPlayer(Transform _newPlayerPos)
    {
        this.transform.position = _newPlayerPos.position;
    }

    private void HitEnemy(float _damage)
    {
        lives -= _damage;
        if (lives <= 0)
        {
            lives = 3;
            EventsManager.instance.EndGame();
        }

        EventsManager.instance.ResetPlayer();
    }

    public void EndGame()
    {

        UnSubscribeEvents();

        Destroy(thePlayer);
    }
}
