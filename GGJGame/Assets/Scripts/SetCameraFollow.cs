using UnityEngine;
using System;

public class SetCameraFollow : MonoBehaviour
{

    private void OnEnable()
    {
        GameManager.OnPlayerSpawned += SetFollow;
    }

    private void SetFollow(GameObject player)
    {
        
    }

    private void OnDisable()
    {
        GameManager.OnPlayerSpawned -= SetFollow;
    }
}
