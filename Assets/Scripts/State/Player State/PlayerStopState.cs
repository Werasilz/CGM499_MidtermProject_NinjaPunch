using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;

    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
        {
            _playerController = playerController;
        }

        Debug.Log("Player Stop");
        // _playerController.animator.Play("Idle");
    }
}
