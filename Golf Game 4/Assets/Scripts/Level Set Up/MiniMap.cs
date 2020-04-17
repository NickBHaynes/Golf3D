using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        EventsManager.instance.OnSetMiniMap += SetMiniMap;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPos = player.position;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
    }

    private void SetMiniMap(Transform _playerPos)
    {
        player = _playerPos;
    }
}
