using System;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #region Global Events

    public event Action<float, int> OnStartGame;
    public void StartGame(float _gameTime, int _resetScore)
    {
        if (OnStartGame != null)
        {
            OnStartGame(_gameTime, _resetScore);
        }
    }

    public event Action<int> OnSpawnLevelDetails;
    public void SpawnLevelDetails(int _levelNum)
    {
        if (OnSpawnLevelDetails != null)
        {
            OnSpawnLevelDetails(_levelNum);
        }
    }

    public event Action OnEndGame;
    public void EndGame()
    {
        if (OnEndGame != null)
        {
            OnEndGame();
        }
    }

    public event Action<Transform> OnSetMiniMap;
    public void SetMiniMap(Transform _playerPos)
    {
        if (OnSetMiniMap != null)
        {
            OnSetMiniMap(_playerPos);
        }
    }

    #endregion

    #region Player Events

    public event Action<int> OnPlayerScore;
    public void PlayerScore(int _score)
    {
        if (OnPlayerScore != null)
        {
            OnPlayerScore(_score);
        }
    }

    public event Action OnResetPlayer;
    public void ResetPlayer()
    {
        if (OnResetPlayer != null)
        {
            OnResetPlayer();
        }
    }

    public event Action<Transform> OnResetPlayerPos;
    public void ResetPlayerPos(Transform _newPlayerPos)
    {
        if (OnResetPlayerPos != null)
        {
            OnResetPlayerPos(_newPlayerPos);
        }
    }

    public event Action<float> OnHitEnemy_Player;
    public void HitEnemy_Player(float _damage)
    {
        if (OnHitEnemy_Player != null)
        {
            OnHitEnemy_Player(_damage);
        }
    }

    #endregion

    #region Ball Events
    public event Action OnResetBall;
    public void ResetBall()
    {
        if (OnResetBall != null)
        {
            OnResetBall();
        }
    }

    public event Action<Transform> OnResetBallPos;
    public void ResetBallPos(Transform _ballPos)
    {
        if (OnResetBallPos != null)
        {
            OnResetBallPos(_ballPos);
        }
    }

    #endregion

    #region Enemy Events

    public event Action OnDestroyEnemy;
    public void DestroyEnemy()
    {
        if (OnDestroyEnemy != null)
        {
            OnDestroyEnemy();
        }
    }
    #endregion

}
