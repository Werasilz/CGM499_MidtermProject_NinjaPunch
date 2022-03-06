using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerTurnState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;

    private Vector3 _turnDirection;
    private float moveDuration = 0.5f;
    private Vector3 originPosition = Vector3.zero;
    private bool isTurn;
    private Vector3 rotateDirection;

    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
        {
            _playerController = playerController;
        }

        _turnDirection.x = (float)_playerController.CurrentTurnDirection;

        if (!isTurn)
        {
            Debug.Log("Player Punch");
            isTurn = true;
            _playerController.animator.SetTrigger("Punch");
            transform.DOMove(_turnDirection, moveDuration).OnComplete(() => transform.DOMove(originPosition, moveDuration / 2).OnComplete(() => isTurn = false));

            if (_playerController.CurrentTurnDirection == PlayerController.Direction.Left)
            {
                rotateDirection = new Vector3(0, -90, 0);
            }
            else
            {
                rotateDirection = new Vector3(0, 90, 0);
            }

            transform.rotation = Quaternion.Euler(rotateDirection);
        }
    }
}
