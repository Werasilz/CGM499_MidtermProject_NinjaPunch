using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    private bool isStart;

    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
        {
            _playerController = playerController;
        }

        if (!isStart)
        {
            Debug.Log("Player Start");
            isStart = true;
            _playerController.animator.SetTrigger("Entry");
            GameManager.Instance.readyText.gameObject.SetActive(true);
        }
    }
}
