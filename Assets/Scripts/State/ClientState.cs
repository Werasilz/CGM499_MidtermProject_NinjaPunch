using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientState : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = (PlayerController)FindObjectOfType(typeof(PlayerController));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _playerController.StartPlayer();
        }

        if (GameManager.Instance.playerHealth > 0)
        {
            if (GameManager.Instance.isStartGame)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    _playerController.TurnPlayer(PlayerController.Direction.Left);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _playerController.TurnPlayer(PlayerController.Direction.Right);
                }
            }
        }

        if (GameManager.Instance.playerHealth <= 0)
        {
            GameManager.Instance.gameOverText.gameObject.SetActive(true);
            _playerController.StopPlayer();
        }
    }
}
