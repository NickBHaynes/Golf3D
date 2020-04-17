using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    void EndGame();

    void SubscribeEvents();

    void UnSubscribeEvents();
}
