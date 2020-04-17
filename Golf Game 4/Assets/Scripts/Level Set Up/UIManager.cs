using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private float gameTime = 999;
    private float score = 0;

    [SerializeField]
    private Text countDownTimer;
    [SerializeField]
    private Text scoreText;

    private void Start()
    {
        EventsManager.instance.OnStartGame += StartGame;
        EventsManager.instance.OnPlayerScore += UpdateScore;
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
        countDownTimer.text = $"Time Left: {(int)gameTime}";

        if (gameTime <= 0)
        {
            EventsManager.instance.EndGame();
        }

    }

    private void StartGame(float _gameTime, int _score)
    {
        gameTime = _gameTime;
        score = _score;
        scoreText.text = $"Score: {score}";
    }

    private void UpdateScore(int _score)
    {
        score += _score;
        scoreText.text = $"Score: {score}";
    }

}
