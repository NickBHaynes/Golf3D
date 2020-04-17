using UnityEngine;

public interface ILevelManager{

    void SubscribeEvents();
    void UnSubscribeEvents();
    void StartGame();
    void EndGame();
}
