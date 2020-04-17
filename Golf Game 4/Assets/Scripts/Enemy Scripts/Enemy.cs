using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    [SerializeField]
    private float playerDamage = 1;

    [SerializeField]
    private float lives = 2;

    [SerializeField]
    GameObject enemy;

    public Material newMat;
    private Renderer meshRend;

    private void Start()
    {
        meshRend = GetComponent<Renderer>();
        SubscribeEvents();
        lives = 2;
    }

    public void SubscribeEvents()
    {

        EventsManager.instance.OnEndGame += EndGame;
    }

    public void UnSubscribeEvents()
    {

        EventsManager.instance.OnEndGame -= EndGame;
    }



    public void EndGame()
    {
        if (enemy != null)
        {
            UnSubscribeEvents();
            Destroy(enemy);
        }
    }

    private void OnCollisionEnter(Collision _otherCollider)
    {
        if (_otherCollider.gameObject.CompareTag("Player"))
        {
            EventsManager.instance.HitEnemy_Player(playerDamage);
        }
        if (_otherCollider.gameObject.CompareTag("Ball"))
        {
            HitBall();
        }
    }

    private void HitBall()
    {
        EventsManager.instance.ResetBall();
        meshRend.sharedMaterial = newMat;

        lives -= 1;

        if (lives <= 0)
        {
            EventsManager.instance.DestroyEnemy();
            Destroy(enemy);
            
        }
    }

}
